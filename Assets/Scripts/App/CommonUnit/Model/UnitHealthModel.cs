using System;
using System.Collections;
using System.Collections.Generic;
using Unit.Model;
using UnityEngine.Assertions;
using UnityEngine;
using App.CommonUnit.Config;

namespace App.CommonUnit.Model
{
    public class UnitHealthModel : IHealthModel
    {
        public bool IsAlive { get; private set; }
        public float MaxHealth { get; }
        public float CurrentHealth { get; private set; }

        public event Action<DamageInfo> OnDamageTaken;
        public event Action OnDeath;

        public UnitHealthModel(UnitConfig config)
        {
            IsAlive = true;
            MaxHealth = config.MaxHealth;
            CurrentHealth = MaxHealth;
        }

        public void TakeDamage(DamageInfo damageInfo)
        {
            if (!IsAlive) return;

            Assert.IsFalse(damageInfo.Damage < 0, "Damage cannot be equal to a negative number");
            CurrentHealth = Mathf.Clamp(CurrentHealth - damageInfo.Damage, 0, MaxHealth);
            IsAlive = CurrentHealth != 0;
            if (!IsAlive) OnDeath?.Invoke();
            OnDamageTaken?.Invoke(damageInfo);
        }
    }
}