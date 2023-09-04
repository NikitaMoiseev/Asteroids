using UnityEngine;
using Unit.Model;
using System;

namespace Projectile.Model
{
    public class ProjectileModel : IProjectileModel
    {
        public DamageInfo DamageInfo { get; }

        public Vector3 Direction { get; }

        public ProjectileModel(DamageInfo damageInfo, Vector3 direction)
        {
            DamageInfo = damageInfo;
            Direction = direction;
        }

        public event Action OnDamage;

        public void Damage(Unit.Unit unit)
        {
            unit.Health.TakeDamage(DamageInfo);
            OnDamage?.Invoke();
        }
    }
}