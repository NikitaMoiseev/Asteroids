using App.CommonUnit.Config.Attack;
using App.CommonUnit.Model;
using App.Enemy.Manager;
using App.Player.Config;
using App.Player.Model;
using ObjectFactory;
using System;
using App.UI.Screens.PlayerInfo;
using UnityEngine;
using UnityEngine.Assertions;

namespace App.Player.Manager
{
    public class PlayerManager : IDisposable
    {
        public Unit.Unit Player { get; private set; }
        public int Score { get; private set; }

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
                _playerConfig.Reward,
                new UnitHealthModel(_playerConfig),
                new UnitMovementModel(_playerConfig),
                new UnitRotateModel(_playerConfig),
                new GunReloadableAttackModel(_attackConfigs.GetConfig(_playerConfig.AttackId), _projectileSpawner),
                new LaserReloadableAttackModel(_attackConfigs.GetConfig(_playerConfig.SecondAttackId), _projectileSpawner));
            Player.Init(playerModel);
            Player.OnDeathAction += OnPlayerDeath;
            Player.transform.position = position;
        }

        public void AddScore(Unit.Unit unit)
        {
            Score += unit.Model.Reward;
        }

        private void OnPlayerDeath(Unit.Unit unit) => ResetPlayer();

        public PlayerInfoModel FindPlayerInfoModel()
        {
            if(Player == null || Player.Model == null)
                return null;

            var playerUnitModel = Player.Model as PlayerUnitModel;
            Assert.IsNotNull(playerUnitModel, "Player must use PlayerUnitModel");
            return new PlayerInfoModel(
                    Player.transform.position.ToString(),
                    Player.transform.rotation.eulerAngles.ToString(),
                    Player.Model.MovementModel.Velocity.magnitude.ToString(),
                    playerUnitModel.SecondAttackModel.ChargesCount.ToString() + "/" +
                    playerUnitModel.SecondAttackModel.ChargesMaxCount.ToString(),
                    (playerUnitModel.SecondAttackModel.AttackInterval - 
                    playerUnitModel.SecondAttackModel.ReloadTimerValue).ToString()
                    );
        }

        private void ResetPlayer()
        {
            if(Player)
                Player.OnDeathAction -= OnPlayerDeath;
            Player = null;
        }

        public void Dispose()
        {
            ResetPlayer();
            Score = 0;
        }
    }
}