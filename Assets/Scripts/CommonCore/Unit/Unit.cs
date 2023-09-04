using CommonComponents;
using Extensions;
using ObjectFactory.Components;
using System;
using System.Collections;
using System.Collections.Generic;
using Unit.Components;
using Unit.Model;
using UnityEngine;

namespace Unit
{
    [RequireComponent(typeof(UnitHealth))]
    public class Unit : MonoBehaviour
    {
        private IUnitModel _model;

        private UnitHealth _health;

        public UnitHealth Health => _health;
        public bool IsAlive => _model.HealthModel.IsAlive;
        public string Id => _model.Id;

        public event Action<Unit> OnDeathAction;

        private void Awake()
        {
            _health = gameObject.RequireComponent<UnitHealth>();
        }

        public void Init(IUnitModel unitModel)
        {
            _model = unitModel;
            InitComponents();
            _model.HealthModel.OnDeath += OnDeath;
        }

        private void InitComponents() => gameObject.InitAllComponentsInChildren(_model);

        private void OnDeath() => OnDeathAction?.Invoke(this);

        private void OnDisable() => Dispose();

        private void Dispose()
        {
            _model.HealthModel.OnDeath -= OnDeath;
            OnDeathAction = null;
        }
    }
}