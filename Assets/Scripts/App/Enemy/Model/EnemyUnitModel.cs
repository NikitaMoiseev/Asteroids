using Unit.Model;
using static UnityEngine.InputSystem.LowLevel.InputStateHistory;

namespace App.Enemy.Model
{
    public class EnemyUnitModel : IUnitModel
    {
        public string Id { get; }
        public int Reward { get; }
        public IHealthModel HealthModel { get; }
        public IMovementModel MovementModel { get; }
        public IRotateModel RotateModel { get; }
        public IAttackModel AttackModel { get; }

        public EnemyUnitModel(string id, int reward, IHealthModel healthModel, IMovementModel movementModel, IRotateModel rotateModel, IAttackModel attackModel)
        {
            Id = id;
            Reward = reward;
            HealthModel = healthModel;
            MovementModel = movementModel;
            RotateModel = rotateModel;
            AttackModel = attackModel;
        }
    }
}