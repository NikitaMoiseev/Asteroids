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

        private void Awake()
        {
            _health = gameObject.RequireComponent<UnitHealth>();
        }

        public void Init(IUnitModel unitModel)
        {
            _model = unitModel;
            InitComponents();
        }

        private void InitComponents() => gameObject.InitAllComponentsInChildren(_model);
    }
}