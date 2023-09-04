using CommonComponents;
using Unit.Model;
using UnityEngine;
using UnityEngine.InputSystem;

namespace App.Player.Components
{
    public class PlayerRotationInput : MonoBehaviour, IInitializable<Unit.Unit>
    {
        private IRotateModel _rotateModel;
        private float _rotateInput;
        public void Init(Unit.Unit data)
        {
            _rotateModel = data.Model.RotateModel;
        }
        public void OnRotate(InputAction.CallbackContext callbackContext)
        {
            _rotateInput = callbackContext.ReadValue<float>();
        }

        public void Update() => RotateUpdate();

        public void RotateUpdate()
        {
            _rotateModel.SetRotateDirection(_rotateInput);
        }

    }
}