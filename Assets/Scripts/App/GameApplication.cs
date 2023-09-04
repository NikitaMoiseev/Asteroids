using ObjectResources.Manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using App.Factory;
using App.Player.Manager;
using App.CommonUnit.Config.Attack;
using App.GameBounds;
using Extensions;
using App.Enemy.Manager;
using App.Enemy.Config;

namespace App
{
    public class GameApplication : MonoBehaviour
    {
        [SerializeField] private FactoryManager _factoryManager;
        [SerializeField] private BoundsSize _boundsSize;
        [Header("Configs")]
        [SerializeField] private AttackConfigsSO _attackConfigs;
        [SerializeField] private PlayerConfigSO _playerConfig;
        [SerializeField] private EnemyConfigsSO _enemyConfigs;

        private ObjectResourceManager _resourceManager;
        private PlayerManager _playerManager;
        private EnemySpawner _enemySpawner;
        private ProjectileSpawner _projectileSpawner;

        private void Awake()
        {
            _resourceManager = new ObjectResourceManager();
            _factoryManager.Init(_resourceManager);
            _boundsSize.Init();
            _projectileSpawner = new ProjectileSpawner(_factoryManager.Factory);
            _playerManager = new PlayerManager(_playerConfig.Config, _factoryManager.Factory, _attackConfigs, _projectileSpawner);
            _enemySpawner = new EnemySpawner(_enemyConfigs, _factoryManager.Factory, _attackConfigs, _playerManager);
            _playerManager.SpawnPlayer(Vector3.zero);
            _enemySpawner.SpawnEnemy("BigAsteroid" , Vector3.up * 3);
        }

        private void OnDestroy()
        {
            _playerManager.Dispose();
            _factoryManager.Dispose();
        }
    }
}