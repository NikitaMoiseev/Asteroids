using App.Enemy.Manager;
using App.Player.Manager;
using App.Session.Config;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

namespace App.Session
{
    public class GameSession
    {
        private SessionConfigSO _sessionConfig;
        private PlayerManager _playerManager;
        private EnemyManager _enemyManager;
        private Action _onPlayerLose;

        private float _timer;
        private float _timerDuration;

        public GameSession(SessionConfigSO sessionConfig, PlayerManager playerManager, EnemyManager enemyManager, Action onPlayerLose)
        {
            _sessionConfig = sessionConfig;
            _playerManager = playerManager;
            _enemyManager = enemyManager;
            _onPlayerLose = onPlayerLose;
            _timerDuration = _sessionConfig.RandomUfoSpawnTimer;
        }

        public void OnTick()
        {
            UpdateUfoTimer();
            SpawnAsteroids();
            CheckPlayerLife();
        }

        private void CheckPlayerLife()
        {
            if (_playerManager.Player == null || !_playerManager.Player.IsAlive)
                _onPlayerLose?.Invoke();
        }

        private void UpdateUfoTimer()
        {
            _timer += Time.deltaTime;
            if (_timer >= _timerDuration)
            {
                _enemyManager.SpawnUFO();
                _timer = 0;
                _timerDuration = _sessionConfig.RandomUfoSpawnTimer;
            }
        }

        private void SpawnAsteroids()
        {
            if(_enemyManager.AsteroidCount < _sessionConfig.MinAsteroidsCoint)
            {
                for(int i = 0; i < _sessionConfig.MaxAsteroidsCoint - _sessionConfig.MinAsteroidsCoint; i++)
                {
                    _enemyManager.SpawnBigAsteroid();
                }
            }    
        }
    }
}