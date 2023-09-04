namespace Unit.Model
{
    public interface IUnitModel
    {
        IHealthModel HealthModel { get; }
        IMovementModel MovementModel { get; }
        IRotateModel RotateModel { get; }
        IAttackModel AttackModel { get; }
    }
}