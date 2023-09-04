using App.CommonUnit.Config.Attack;
using App.Enemy.Manager;
using ObjectFactory;
using System.Collections;
using System.Collections.Generic;
using Unit.Model;
using UnityEngine;

namespace App.CommonUnit.Model
{
    public class ReloadableAttackModel : IAttackModel
    {
        private float _timeLastAttack;
        private ProjectileSpawner _projectileSpawner;

        public string Name { get; }
        public string ProjectileId { get; }
        public float AttackInterval { get; }
        public float HitDamage { get; }
        public float ReloadTimerValue => Mathf.Clamp(Time.time - _timeLastAttack, 0, AttackInterval);
        public bool IsReady => ReloadTimerValue == AttackInterval;

        public ReloadableAttackModel(AttackConfig attackConfig, ProjectileSpawner projectileSpawner)
        {
            Name = attackConfig.Id;
            ProjectileId = attackConfig.ProjectileId;
            AttackInterval = attackConfig.AttackInterval;
            HitDamage = attackConfig.HitDamage;
            _projectileSpawner = projectileSpawner;
        }

        public void Attack(Vector3 direaction, Transform launchTransform)
        {
            if (!IsReady)
                return;
            _timeLastAttack = Time.time;
            _projectileSpawner.SpawnProjectile(ProjectileId, DamageInfo.FromAttackModel(this), direaction, launchTransform);
        }
    }
}