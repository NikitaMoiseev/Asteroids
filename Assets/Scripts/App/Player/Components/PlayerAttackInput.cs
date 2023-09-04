using App.Player.Model;
using CommonComponents;
using Unit.Model;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.InputSystem;

namespace App.Player.Components
{
    public class PlayerAttackInput : MonoBehaviour, IInitializable<IUnitModel>
    {
        [SerializeField] private Transform _launcher;
        private IAttackModel _attackModel;
        private IAttackModel _secondAttackModel;
        public void Init(IUnitModel model)
        {
            var playerUnitModel = model as PlayerUnitModel;
            Assert.IsNotNull(playerUnitModel, "PlayerAttackInput only works with PlayerUnitModel");
            _attackModel = playerUnitModel.AttackModel;
            _secondAttackModel = playerUnitModel.SecondAttackModel;
        }

        public void OnAttack(InputAction.CallbackContext callbackContext)
        {
            if (callbackContext.phase == InputActionPhase.Started)
                _attackModel.Attack(_launcher.up, _launcher.transform);
        }

        public void OnSecondAttack(InputAction.CallbackContext callbackContext)
        {
            if (callbackContext.phase == InputActionPhase.Started)
                _secondAttackModel.Attack(_launcher.up, _launcher.transform);
        }
    }
}