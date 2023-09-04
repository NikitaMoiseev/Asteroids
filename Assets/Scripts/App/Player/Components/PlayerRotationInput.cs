using CommonComponents;
using Unit.Model;
using UnityEngine;
using UnityEngine.InputSystem;

namespace App.Player.Components
{
    public class PlayerRotationInput : MonoBehaviour, IInitializable<IUnitModel>
    {
        private IRotateModel _rotateModel;
        private float _rotateInput;
        public void Init(IUnitModel model)
        {
            _rotateModel = model.RotateModel;
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