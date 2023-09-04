using CommonComponents;
using Unit.Model;
using UnityEngine;

namespace App.Enemy.Components
{
    public class AsteroidMovementInput : MonoBehaviour, IInitializable<IUnitModel>
    {
        private IMovementModel _movementModel;
        private Vector2 _randomDirection;
        public void Init(IUnitModel model)
        {
            _movementModel = model.MovementModel;
            _randomDirection = Random.insideUnitCircle;
        }

        public void Update() => MovementUpdate();

        public void MovementUpdate()
        {
            _movementModel.UpdateVelocity(_randomDirection);
        }
    }
}