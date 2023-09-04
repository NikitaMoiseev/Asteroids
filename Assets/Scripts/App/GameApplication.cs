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
using Codice.Client.BaseCommands.Merge;
using App.Player.Config;
using App.Session.Config;
using App.Session;
using System;
using App.UI.Manager;

namespace App
{
    public class GameApplication : MonoBehaviour
    {
        [SerializeField] private EnemyManager _enemyManager;
        [SerializeField] private FactoryManager _factoryManager;
        [SerializeField] private BoundsSize _boundsSize;
        [SerializeField] private UIManager _uiManager;
        [Header("Configs")]
        [SerializeField] private AttackConfigsSO _attackConfigs;
        [SerializeField] private PlayerConfigSO _playerConfig;
        [SerializeField] private EnemyConfigsSO _enemyConfigs;
        [SerializeField] private SessionConfigSO _sessionConfig;

        private ObjectResourceManager _resourceManager;
        private PlayerManager _playerManager;
        private EnemySpawner _enemySpawner;
        private ProjectileSpawner _projectileSpawner;
        private GameSession _gameSession;

        private void Awake()
        {
            _resourceManager = new ObjectResourceManager();
            _factoryManager.Init(_resourceManager);
            _boundsSize.Init();
            _projectileSpawner = new ProjectileSpawner(_factoryManager.Factory);
            _playerManager = new PlayerManager(_playerConfig.Config, _factoryManager.Factory, _attackConfigs, _projectileSpawner);
            _enemySpawner = new EnemySpawner(_enemyConfigs, _factoryManager.Factory, _attackConfigs, _playerManager);
            _enemyManager.Init(_enemySpawner, _boundsSize);
            StartSession();
        }

        private void Update() => UpdateSession();

        public void StartSession()
        {
            if (_gameSession != null)
                return;
            _playerManager.SpawnPlayer(Vector3.zero);
            _gameSession = new GameSession(_sessionConfig, _playerManager, _enemyManager, EndSession);
        }

        private void UpdateSession()
        {
            if (_gameSession == null)
                return;
            _uiManager.SetPlayerInfoScreen(_playerManager.FindPlayerInfoModel());
            _gameSession.OnTick();
        }

        public void EndSession()
        {
            _gameSession = null;
            _uiManager.SetDebriefingScreen(new UI.Screens.Debriefing.DebriefingModel(StartSession, _playerManager.Score));
            Dispose();
        }


        private void OnDestroy() => Dispose();

        private void Dispose()
        {
            _playerManager.Dispose();
            _factoryManager.DestroyAllObjects();
            _enemyManager.Clear();
        }
    }
}