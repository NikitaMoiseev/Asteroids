using App.GameBounds;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace App.Enemy.Manager
{
    public class EnemyManager : MonoBehaviour
    {
        [SerializeField] private Vector2 _spawnScreenSizeOffset = Vector2.one / 2;
        [SerializeField] private int _smallAsteroidsSpawnCount;
        [SerializeField] private string _bigAsteroidId;
        [SerializeField] private string _smallAsteroidId;
        [SerializeField] private string _ufoId;

        private EnemySpawner _spawner;
        private BoundsSize _boundsSize;
        private List<Unit.Unit> _units = new List<Unit.Unit>();

        public int AsteroidCount => _units.Where(it => it != null && (it.Id == _bigAsteroidId || it.Id == _smallAsteroidId)).Count();
        public int UFOCount => _units.Where(it => it != null && it.Id == _ufoId).Count();

        public void Init(EnemySpawner enemySpawner, BoundsSize boundsSize)
        {
            _spawner = enemySpawner;
            _boundsSize = boundsSize;
        }

        public void SpawnUFO()
        {
            var unit = _spawner.SpawnUFO(_ufoId, GetRandomSpawnPosition());
            unit.OnDeathAction += RemoveUnit;
            _units.Add(unit);
        }


        public void SpawnBigAsteroid()
        {
            var unit = _spawner.SpawnAsteroid(_bigAsteroidId, GetRandomSpawnPosition());
            unit.OnDeathAction += SpawnSmallAsteroids;
            unit.OnDeathAction += RemoveUnit;
            _units.Add(unit);
        }

        public void SpawnSmallAsteroids(Unit.Unit unit)
        {
            unit.OnDeathAction -= SpawnSmallAsteroids;
            for (int i = 0; i < _smallAsteroidsSpawnCount; i++)
            {
                var newUnit = _spawner.SpawnAsteroid(_smallAsteroidId, unit.transform.position);
                _units.Add(newUnit);
                newUnit.OnDeathAction += RemoveUnit;
            }
        }

        private void RemoveUnit(Unit.Unit unit)
        {
            _units.Remove(unit);
            unit.OnDeathAction -= RemoveUnit;
        }

        private Vector3 GetRandomSpawnPosition()
        {
            var size = (_boundsSize.Size - _spawnScreenSizeOffset) / 2;
            var side = Random.Range(0, 4);
            switch (side)
            {
                case 0: return new Vector3(Random.Range(-size.x, size.x), -size.y);
                case 1: return new Vector3(Random.Range(-size.x, size.x), size.y);
                case 2: return new Vector3(-size.x, Random.Range(-size.y, size.y));
                case 3: return new Vector3(size.x, Random.Range(-size.y, size.y));
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void Clear()
        {
            _units.Clear();
        }
    }
}