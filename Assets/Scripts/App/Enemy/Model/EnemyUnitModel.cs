using Unit.Model;

namespace App.Enemy.Model
{
    public class EnemyUnitModel : IUnitModel
    {
        public IHealthModel HealthModel { get; }
        public IMovementModel MovementModel { get; }
        public IRotateModel RotateModel { get; }
        public IAttackModel AttackModel { get; }


        public EnemyUnitModel(IHealthModel healthModel, IMovementModel movementModel, IRotateModel rotateModel, IAttackModel attackModel)
        {
            HealthModel = healthModel;
            MovementModel = movementModel;
            RotateModel = rotateModel;
            AttackModel = attackModel;
        }
    }
}