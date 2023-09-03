using CommonComponents;
using System;
using Unit.Model;
using UnityEngine;

namespace Unit.Components
{
    public class UnitHealth : MonoBehaviour, IInitializable<IUnitModel>
    {
        private IHealthModel _healthModel;

        public void Init(IUnitModel model)
        {
            _healthModel = model.HealthModel;
        }

        public void TakeDamage(DamageInfo damage)
        {
            _healthModel.TakeDamage(damage);
        }

        private void OnDisable() => _healthModel = null;
    }
}