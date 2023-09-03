using CommonComponents;
using Unit.Model;
using UnityEngine;

namespace Unit.Components
{
    public class UnitMovement : MonoBehaviour, IInitializable<IUnitModel>
    {
        private IMovementModel _movementModel;

        public void Init(IUnitModel model)
        {
            _movementModel = model.MovementModel;
        }

        public void Update()
        {
            var velocity = _movementModel.Velocity * Time.deltaTime;
            transform.position += velocity;
        }

        private void OnDisable() => _movementModel = null;
    }
}