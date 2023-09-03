using CommonComponents;
using Extensions;
using ObjectFactory.Components;
using System;
using System.Collections;
using System.Collections.Generic;
using Unit.Model;
using UnityEngine;

namespace Unit
{
    [RequireComponent(typeof(Destroyer))]
    public class Unit : MonoBehaviour
    {
        public IUnitModel Model { get; private set; }

        private Destroyer _destroyer;

        private void Awake()
        {
            _destroyer = GetComponent<Destroyer>();
        }

        public void Init(IUnitModel unitModel)
        {
            Model = unitModel;
            InitComponents();
        }

        private void InitComponents() => gameObject.InitAllComponentsInChildren(this);

        public void Destroy() => _destroyer.Destroy();

        private void OnDisable() => Dispose();

        private void Dispose()
        {

        }
    }
}