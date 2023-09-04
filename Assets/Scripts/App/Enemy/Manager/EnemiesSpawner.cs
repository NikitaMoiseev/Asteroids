using App.CommonUnit.Config;
using App.CommonUnit.Config.Attack;
using App.CommonUnit.Model;
using App.Enemy.Config;
using App.Enemy.Model;
using App.Player.Config;
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
        private ProjectileSpawner _projectileSpawner;

        public EnemiesSpawner(
            EnemyConfigsSO enemyConfigs, 
            IObjectFactory factory,
            AttackConfigsSO attackConfigsSO,
            ProjectileSpawner projectileSpawner)
        {
            _enemyConfigs = enemyConfigs;
            _objectFactory = factory;
            _attackConfigs = attackConfigsSO;
            _projectileSpawner = projectileSpawner;
        }

        public Unit.Unit SpawnEnemy(string id, Vector3 position, Action OnDeadAction)
        {
            var config = _enemyConfigs.GetConfig(id);
            var unit = _objectFactory.Create<Unit.Unit>(config.Id);
            var unitModel = new EnemyUnitModel(
                new UnitHealthModel(config),
                new UnitMovementModel(config),
                new UnitRotateModel(config),
                new ReloadableAttackModel(_attackConfigs.GetConfig(config.AttackId), _projectileSpawner));
            unit.Init(unitModel);
            unitModel.HealthModel.OnDead += OnDeadAction;
            unit.transform.position = position;
            return unit;
        }
    }
}