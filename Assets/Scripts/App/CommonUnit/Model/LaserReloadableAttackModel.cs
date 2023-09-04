using App.CommonUnit.Config.Attack;
using App.Enemy.Manager;
using Unit.Model;
using UnityEngine;

namespace App.CommonUnit.Model
{
    public class LaserReloadableAttackModel : ReloadableAttackModel
    {
        private ProjectileSpawner _projectileSpawner;

        public LaserReloadableAttackModel(AttackConfig attackConfig, ProjectileSpawner projectileSpawner) : base(attackConfig)
        {
            _projectileSpawner = projectileSpawner;
        }

        protected override void OnAttack(Vector3 direction, Transform launchTransform)
        {
            var projectile = _projectileSpawner.SpawnProjectile(ProjectileId, DamageInfo.FromAttackModel(this), direction, launchTransform);
            projectile.transform.SetParent(launchTransform);
        }

        public override void OnTick()
        {
            if (_chargesNumber >= ChargesMaxCount)
                return;

            _timer += Time.deltaTime;
            if (_timer > AttackInterval)
            {
                _chargesNumber++;
                _timer = 0;
            }
        }
    }
}