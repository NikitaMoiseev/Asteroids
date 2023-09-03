using System.Collections;
using System.Collections.Generic;
using Unit.Model;
using UnityEngine;

namespace App.Player.Model
{
    public class PlayerUnitModel : IUnitModel
    {
        public IHealthModel HealthModel { get; }
        public IMovementModel MovementModel { get; }
        public IAttackModel AttackModel { get; }
        public IAttackModel SecondAttackModel { get; }

        public PlayerUnitModel(IHealthModel healthModel, IMovementModel movementModel, IAttackModel attackModel, IAttackModel secondAttackModel)
        {
            HealthModel = healthModel;
            MovementModel = movementModel;
            AttackModel = attackModel;
            SecondAttackModel = secondAttackModel;
        }
    }
}