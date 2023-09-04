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

        public int AsteroidCount => _units.Where(it => it.Id == _bigAsteroidId || it.Id == _smallAsteroidId).Count();
        public int UFOCount => _units.Where(it => it.Id == _ufoId).Count();

        public EnemyManager(EnemySpawner enemySpawner, BoundsSize boundsSize)
        {
            _spawner = enemySpawner;
            _boundsSize = boundsSize;
        }

        public void SpawnUFO()
        {
            var unit = _spawner.SpawnEnemy(_bigAsteroidId, GetRandomSpawnPosition());
            unit.OnDeathAction += SpawnSmallAsteroids;
            unit.OnDeathAction += SpawnSmallAsteroids;
            _units.Add(unit);
        }


        public void SpawnBigAsteroid()
        {
            var unit = _spawner.SpawnEnemy(_bigAsteroidId, GetRandomSpawnPosition());
            unit.OnDeathAction += SpawnSmallAsteroids;
            unit.OnDeathAction += RemoveUnit;
            _units.Add(unit);
        }

        public void SpawnSmallAsteroids(Unit.Unit unit)
        {
            unit.OnDeathAction -= SpawnSmallAsteroids;
            for (int i = 0; i < _smallAsteroidsSpawnCount; i++)
            {
                var newUnit = _spawner.SpawnEnemy(_smallAsteroidId, GetRandomSpawnPosition());
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
            var size = _boundsSize.Size - _spawnScreenSizeOffset;
            var side = Random.Range(0, 4);
            switch (side)
            {
                case 0: return new Vector3(Random.Range(0, size.x), 0);
                case 1: return new Vector3(Random.Range(0, size.x), size.y);
                case 2: return new Vector3(0, Random.Range(0, size.y));
                case 3: return new Vector3(size.x, Random.Range(0, size.y));
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void Dispose()
        {
            _units.Clear();
        }
    }
}