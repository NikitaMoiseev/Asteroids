﻿using System;

namespace Unit.Model
{
    public interface IHealthModel
    {
        bool IsAlive { get; }
        float MaxHealth { get; }
        float CurrentHealth { get; }

        event Action<DamageInfo> OnDamageTaken;
        event Action OnDeath;

        void TakeDamage(DamageInfo damage);
    }
}