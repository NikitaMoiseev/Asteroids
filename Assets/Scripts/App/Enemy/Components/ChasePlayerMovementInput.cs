using App.Enemy.Model;
using App.Player.Model;
using CommonComponents;
using Unit.Model;
using UnityEditor;
using UnityEngine;
using UnityEngine.Assertions;

namespace App.Enemy.Components
{
    public class ChasePlayerMovementInput : MonoBehaviour, IInitializable<Unit.Unit>
    {
        private ChasePlayerMovementModel _movementModel;

        public void Init(Unit.Unit data)
        {
            var chaseMovementModel = data.Model.MovementModel as ChasePlayerMovementModel;
            Assert.IsNotNull(chaseMovementModel, "ChasePlayerMovementInput only works with ChasePlayerMovementModel");
            _movementModel = chaseMovementModel;
        }

        public void Update() => MovementUpdate();

        public void MovementUpdate()
        {
            _movementModel.UpdateVelocity(GetToPlayerDirection());
        }

        private Vector3 GetToPlayerDirection()
        {
            if (_movementModel.PlayerUnit)
                return _movementModel.PlayerUnit.transform.position - transform.position;
            else
                return transform.up;
        }
    }
}