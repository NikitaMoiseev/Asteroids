using App.CommonUnit.Config.Attack;
using App.CommonUnit.Model;
using App.Player.Manager;
using Unit.Model;
using UnityEngine;

namespace App.Enemy.Model
{
    public class EnemyAttackModel : ReloadableAttackModel
    {
        private PlayerManager _playerManager;

        public EnemyAttackModel(AttackConfig attackConfig, PlayerManager playerManager) : base(attackConfig)
        {
            _playerManager = playerManager;
        }

        protected override void OnAttack(Vector3 _, Transform __)
        {
            if (!_playerManager.Player || !_playerManager.Player.IsAlive)
                return;
            _playerManager.Player.Health.TakeDamage(DamageInfo.FromAttackModel(this));
        }
    }
}