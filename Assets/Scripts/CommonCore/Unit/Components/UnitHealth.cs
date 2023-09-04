using CommonComponents;
using System;
using Unit.Model;
using UnityEngine;

namespace Unit.Components
{
    public class UnitHealth : MonoBehaviour, IInitializable<Unit>
    {
        private IHealthModel _healthModel;

        public void Init(Unit data)
        {
            _healthModel = data.Model.HealthModel;
        }

        public void TakeDamage(DamageInfo damage)
        {
            _healthModel.TakeDamage(damage);
        }

        private void OnDisable() => _healthModel = null;
    }
}