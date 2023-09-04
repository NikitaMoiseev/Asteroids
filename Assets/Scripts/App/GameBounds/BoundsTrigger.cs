using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace App.GameBounds
{
    public class BoundsTrigger : MonoBehaviour
    {
        public event Action<Unit.Unit> OnUnitExit;

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out Unit.Unit unit))
                OnUnitExit?.Invoke(unit);
        }
    }
}