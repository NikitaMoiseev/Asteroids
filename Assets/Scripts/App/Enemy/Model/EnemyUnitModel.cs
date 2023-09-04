using Unit.Model;

namespace App.Enemy.Model
{
    public class EnemyUnitModel : IUnitModel
    {
        public string Id { get; }
        public IHealthModel HealthModel { get; }
        public IMovementModel MovementModel { get; }
        public IRotateModel RotateModel { get; }
        public IAttackModel AttackModel { get; }

        public EnemyUnitModel(string id, IHealthModel healthModel, IMovementModel movementModel, IRotateModel rotateModel, IAttackModel attackModel)
        {
            Id = id;
            HealthModel = healthModel;
            MovementModel = movementModel;
            RotateModel = rotateModel;
            AttackModel = attackModel;
        }
    }
}