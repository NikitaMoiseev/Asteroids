using App.CommonUnit.Config;
using App.CommonUnit.Config.Attack;
using App.CommonUnit.Model;
using App.Enemy.Config;
using App.Enemy.Model;
using App.Player.Config;
using App.Player.Manager;
using App.Player.Model;
using ObjectFactory;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace App.Enemy.Manager
{
    public class EnemiesSpawner
    {
        private EnemyConfigsSO _enemyConfigs;
        private IObjectFactory _objectFactory;
        private AttackConfigsSO _attackConfigs;
        private PlayerManager _playerManager;

        public EnemiesSpawner(
            EnemyConfigsSO enemyConfigs, 
            IObjectFactory factory,
            AttackConfigsSO attackConfigsSO,
            PlayerManager playerManager)
        {
            _enemyConfigs = enemyConfigs;
            _objectFactory = factory;
            _attackConfigs = attackConfigsSO;
            _playerManager = playerManager;
        }

        public Unit.Unit SpawnEnemy(string id, Vector3 position, Action OnDeadAction)
        {
            var config = _enemyConfigs.GetConfig(id);
            var unit = _objectFactory.Create<Unit.Unit>(config.Id);
            var unitModel = new EnemyUnitModel(
                new UnitHealthModel(config),
                new UnitMovementModel(config),
                new UnitRotateModel(config),
                new EnemyAttackModel(_attackConfigs.GetConfig(config.AttackId), _playerManager));
            unit.Init(unitModel);
            unitModel.HealthModel.OnDead += OnDeadAction;
            unit.transform.position = position;
            return unit;
        }
    }
}