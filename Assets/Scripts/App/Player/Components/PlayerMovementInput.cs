using CommonComponents;
using Unit.Model;
using UnityEngine;
using UnityEngine.InputSystem;

namespace App.Player.Components
{
    public class PlayerMovementInput : MonoBehaviour, IInitializable<IUnitModel>
    {
        private IMovementModel _movementModel;
        private bool _isMovementInput = false;
        public void Init(IUnitModel model)
        {
            _movementModel = model.MovementModel;
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