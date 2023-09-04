using UnityEngine;
using Unit.Model;
using System;

namespace Projectile.Model
{
    public interface IProjectileModel
    {
        DamageInfo DamageInfo { get; }
        Vector3 Direction { get; }

        event Action OnDamage;

        void Damage(Unit.Unit unit);
    }
}