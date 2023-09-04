using Unit.Model;
using static UnityEngine.InputSystem.LowLevel.InputStateHistory;

namespace App.Player.Model
{
    public class PlayerUnitModel : IUnitModel
    {
        public string Id { get; }
        public int Reward { get; }
        public IHealthModel HealthModel { get; }
        public IMovementModel MovementModel { get; }
        public IRotateModel RotateModel { get; }
        public IAttackModel AttackModel { get; }
        public IAttackModel SecondAttackModel { get; }

        public PlayerUnitModel(string id, int reward, IHealthModel healthModel, IMovementModel movementModel, IRotateModel rotateModel, IAttackModel attackModel, IAttackModel secondAttackModel)
        {
            Id = id;
            Reward = reward;
            HealthModel = healthModel;
            MovementModel = movementModel;
            RotateModel = rotateModel;
            AttackModel = attackModel;
            SecondAttackModel = secondAttackModel;
        }
    }
}