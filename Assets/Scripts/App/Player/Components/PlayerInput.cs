using CommonComponents;
using Unit.Model;
using UnityEngine;
using UnityEngine.InputSystem;

namespace App.Player.Components
{
    public class PlayerInput : MonoBehaviour, IInitializable<IUnitModel>
    {
        private IMovementModel _movementModel;

        public void Init(IUnitModel model)
        {
            _movementModel = model.MovementModel;
        }

        public void OnMovement(InputAction.CallbackContext callbackContext)
        {
            Debug.Log("Move: " + callbackContext.phase);
        }

        public void Update()
        {

        }

        public void MoveInput()
        {

        }

    }
}