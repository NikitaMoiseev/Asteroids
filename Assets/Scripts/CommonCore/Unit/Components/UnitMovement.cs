using CommonComponents;
using Unit.Model;
using UnityEngine;

namespace Unit.Components
{
    public class UnitMovement : MonoBehaviour, IInitializable<Unit>
    {
        private IMovementModel _movementModel;

        public void Init(Unit data)
        {
            _movementModel = data.Model.MovementModel;
        }

        public void Update()
        {
            var velocity = _movementModel.Velocity * Time.deltaTime;
            transform.position += velocity;
        }

        private void OnDisable() => _movementModel = null;
    }
}