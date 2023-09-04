namespace Unit.Model
{
    public interface IUnitModel
    {
        string Id { get; }
        int Reward { get; }
        IHealthModel HealthModel { get; }
        IMovementModel MovementModel { get; }
        IRotateModel RotateModel { get; }
        IAttackModel AttackModel { get; }
    }
}