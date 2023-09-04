using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace App.GameBounds
{
    [RequireComponent(typeof(BoundsTrigger))]
    [RequireComponent(typeof(BoundsSize))]
    public class WarpObjects : MonoBehaviour
    {
        private BoundsTrigger _boundsTrigger;
        private BoundsSize _boundsSize;


        private void Awake()
        {
            _boundsTrigger = GetComponent<BoundsTrigger>();
            _boundsSize = GetComponent<BoundsSize>();
            _boundsTrigger.OnUnitExit += OnUnitExit;
        }

        private void OnUnitExit(Unit.Unit unit)
        {
            var transform = unit.transform;
            if (Mathf.Abs(transform.position.x) > _boundsSize.Size.x / 2)
                transform.position = new Vector3(
                    transform.position.x * -1, 
                    transform.position.y,
                    transform.position.z);
            if (Mathf.Abs(transform.position.y) > _boundsSize.Size.y / 2)
                transform.position = new Vector3(
                    transform.position.x, 
                    transform.position.y * -1,
                    transform.position.z);
        }

        private void OnDestroy() => Dispose();

        private void Dispose()
        {
            _boundsTrigger.OnUnitExit -= OnUnitExit;
        }
    }
}