using CommonComponents;
using ObjectFactory.Components;
using System;
using Unit.Model;
using UnityEngine;

namespace Unit.Components
{
    [RequireComponent(typeof(Destroyer))]
    public class UnitDeath : MonoBehaviour, IInitializable<IUnitModel>
    {
        private IHealthModel _healthModel;
        private Destroyer _destroyer;

        public void Init(IUnitModel model)
        {
            _healthModel = model.HealthModel;
            _destroyer = gameObject.GetComponent<Destroyer>();
            _healthModel.OnDamageTaken += OnDamageTaken;
        }

        public void OnDamageTaken(DamageInfo damage)
        {
            if (_healthModel.IsAlive)
                return;
            Destroy();
        }

        public void Destroy() => _destroyer.Destroy();

        private void OnDisable() => Dispose();

        private void Dispose()
        {
            if (_healthModel != null)
                _healthModel.OnDamageTaken -= OnDamageTaken;
            _healthModel = null;
        }
    }
}