using App.CommonUnit.Config.Attack;
using App.Enemy.Manager;
using ObjectFactory;
using System.Collections;
using System.Collections.Generic;
using Unit.Model;
using UnityEngine;

namespace App.CommonUnit.Model
{
    public class GunReloadableAttackModel : ReloadableAttackModel
    {
        private ProjectileSpawner _projectileSpawner;

        public GunReloadableAttackModel(AttackConfig attackConfig, ProjectileSpawner projectileSpawner) : base(attackConfig)
        {
            _projectileSpawner = projectileSpawner;
        }

        protected override void OnAttack(Vector3 direction, Transform launchTransform)
        {
            _projectileSpawner.SpawnProjectile(ProjectileId, DamageInfo.FromAttackModel(this), direction, launchTransform);
        }
    }
}