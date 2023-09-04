using Unit.Model;

namespace App.Player.Model
{
    public class PlayerUnitModel : IUnitModel
    {
        public IHealthModel HealthModel { get; }
        public IMovementModel MovementModel { get; }
        public IRotateModel RotateModel { get; }
        public IAttackModel AttackModel { get; }
        public IAttackModel SecondAttackModel { get; }


        public PlayerUnitModel(IHealthModel healthModel, IMovementModel movementModel, IRotateModel rotateModel, IAttackModel attackModel, IAttackModel secondAttackModel)
        {
            HealthModel = healthModel;
            MovementModel = movementModel;
            RotateModel = rotateModel;
            AttackModel = attackModel;
            SecondAttackModel = secondAttackModel;
        }
    }
}