using CommonComponents;
using Unit.Model;
using UnityEditor;
using UnityEngine;

namespace App.Enemy.Components
{
    public class AsteroidMovementInput : MonoBehaviour, IInitializable<Unit.Unit>
    {
        private IMovementModel _movementModel;
        private Vector2 _randomDirection;
        public void Init(Unit.Unit data)
        {
            _movementModel = data.Model.MovementModel;
            _randomDirection = Random.insideUnitCircle;
        }

        public void Update() => MovementUpdate();

        public void MovementUpdate()
        {
            _movementModel.UpdateVelocity(_randomDirection);
        }
    }
}