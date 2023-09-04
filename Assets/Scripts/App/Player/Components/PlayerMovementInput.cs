using CommonComponents;
using Unit.Model;
using UnityEngine;
using UnityEngine.InputSystem;

namespace App.Player.Components
{
    public class PlayerMovementInput : MonoBehaviour, IInitializable<Unit.Unit>
    {
        private IMovementModel _movementModel;
        private bool _isMovementInput = false;
        public void Init(Unit.Unit data)
        {
            _movementModel = data.Model.MovementModel;
        }

        public void OnMovement(InputAction.CallbackContext callbackContext)
        {
            _isMovementInput = callbackContext.phase != InputActionPhase.Canceled;
        }

        public void Update() => MovementUpdate();

        public void MovementUpdate()
        {
            _movementModel.UpdateVelocity(_isMovementInput ? transform.up : Vector3.zero);
        }

    }
}