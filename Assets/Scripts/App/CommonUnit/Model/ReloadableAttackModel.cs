using App.CommonUnit.Config.Attack;
using App.Enemy.Manager;
using ObjectFactory;
using System.Collections;
using System.Collections.Generic;
using Unit.Model;
using UnityEngine;

namespace App.CommonUnit.Model
{
    public abstract class ReloadableAttackModel : IAttackModel
    {
        private float _timeLastAttack;

        public string Name { get; }
        public string ProjectileId { get; }
        public float AttackInterval { get; }
        public float HitDamage { get; }
        public float ReloadTimerValue => Mathf.Clamp(Time.time - _timeLastAttack, 0, AttackInterval);
        public bool IsReady => ReloadTimerValue == AttackInterval;

        public ReloadableAttackModel(AttackConfig attackConfig)
        {
            Name = attackConfig.Id;
            ProjectileId = attackConfig.ProjectileId;
            AttackInterval = attackConfig.AttackInterval;
            HitDamage = attackConfig.HitDamage;
        }

        public void Attack(Vector3 direction, Transform launchTransform)
        {
            if (!IsReady)
                return;
            _timeLastAttack = Time.time;
            OnAttack(direction, launchTransform);
        }

        protected abstract void OnAttack(Vector3 direction, Transform launchTransform);
    }
}