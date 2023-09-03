using System;
using System.Collections;
using System.Collections.Generic;
using Unit.Model;
using UnityEngine.Assertions;
using UnityEngine;

namespace App.CommonUnit.Model
{
    public class UnitHealthModel : IHealthModel
    {
        public bool IsAlive { get; private set; }
        public float MaxHealth { get; }
        public float CurrentHealth { get; private set; }

        public event Action<DamageInfo> OnDamageTaken;

        public UnitHealthModel(float maxHealth)
        {
            MaxHealth = maxHealth;
            CurrentHealth = MaxHealth;
        }

        public void TakeDamage(DamageInfo damageInfo)
        {
            Assert.IsFalse(damageInfo.Damage < 0, "Damage cannot be equal to a negative number");
            CurrentHealth = Mathf.Clamp(CurrentHealth - damageInfo.Damage, 0, MaxHealth);
            IsAlive = CurrentHealth != 0;
            OnDamageTaken?.Invoke(damageInfo);
        }
    }
}