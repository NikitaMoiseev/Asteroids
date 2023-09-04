using CommonComponents;
using Extensions;
using ObjectFactory.Components;
using System;
using System.Collections;
using System.Collections.Generic;
using Unit.Components;
using Unit.Model;
using UnityEngine;
using UnityEngine.UIElements;

namespace Unit
{
    [RequireComponent(typeof(UnitHealth))]
    [RequireComponent(typeof(UnitDeath))]
    public class Unit : MonoBehaviour
    {
        private IUnitModel _model;
        private UnitHealth _health;
        private UnitDeath _unitDeath;

        public IUnitModel Model => _model;
        public UnitHealth Health => _health;
        public bool IsAlive => _model.HealthModel.IsAlive;
        public string Id => _model.Id;

        public event Action<Unit> OnDeathAction;

        private void Awake()
        {
            _unitDeath = GetComponent<UnitDeath>();
            _health = GetComponent<UnitHealth>();
        }

        public void Init(IUnitModel unitModel)
        {
            _model = unitModel;
            InitComponents();
            _model.HealthModel.OnDeath += OnDeath;
        }

        private void InitComponents() => gameObject.InitAllComponentsInChildren(this);

        private void OnDeath()
        {
            OnDeathAction?.Invoke(this);
            _unitDeath.Destroy();
        }

        private void OnDisable() => Dispose();

        private void Dispose()
        {
            if (_model != null)
                _model.HealthModel.OnDeath -= OnDeath;
            OnDeathAction = null;
            _model = null;
        }
    }
}