using CommonComponents;
using ObjectFactory.Components;
using System;
using Unit.Model;
using UnityEngine;

namespace Unit.Components
{
    [RequireComponent(typeof(Destroyer))]
    public class UnitDeath : MonoBehaviour, IInitializable<Unit>
    {
        private Destroyer _destroyer;

        public void Init(Unit data)
        {
            _destroyer = gameObject.GetComponent<Destroyer>();
        }

        public void Destroy() => _destroyer.Destroy();
    }
}