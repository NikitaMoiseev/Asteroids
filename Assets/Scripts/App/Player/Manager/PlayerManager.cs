using App.CommonUnit.Config.Attack;
using App.CommonUnit.Model;
using App.Enemy.Manager;
using App.Player.Config;
using App.Player.Model;
using ObjectFactory;
using System;
using Unit.Model;
using UnityEngine;

namespace App.Player.Manager
{
    public class PlayerManager : IDisposable
    {
        public Unit.Unit Player { get; private set; }

        private PlayerConfig _playerConfig;
        private IObjectFactory _objectFactory;
        private AttackConfigsSO _attackConfigs;
        private ProjectileSpawner _projectileSpawner;

        public PlayerManager(
            PlayerConfig config,
            IObjectFactory factory,
            AttackConfigsSO attackConfigsSO,
            ProjectileSpawner projectileSpawner)
        {
            _playerConfig = config;
            _objectFactory = factory;
            _attackConfigs = attackConfigsSO;
            _projectileSpawner = projectileSpawner;
        }

        public void SpawnPlayer(Vector3 position)
        {
            Player = _objectFactory.Create<Unit.Unit>(_playerConfig.Id);
            var playerModel = new PlayerUnitModel(_playerConfig.Id,
                new UnitHealthModel(_playerConfig),
                new UnitMovementModel(_playerConfig),
                new UnitRotateModel(_playerConfig),
                new GunReloadableAttackModel(_attackConfigs.GetConfig(_playerConfig.AttackId), _projectileSpawner),
                new GunReloadableAttackModel(_attackConfigs.GetConfig(_playerConfig.SecondAttackId), _projectileSpawner));
            Player.Init(playerModel);
            Player.transform.position = position;
        }

        public void Dispose()
        {
            Player = null;
        }
    }
}