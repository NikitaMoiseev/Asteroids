namespace Unit.Model
{
    public interface IUnitModel
    {
        IHealthModel HealthModel { get; }
        IAttackModel AttackModel { get; }
        IMovementModel MovementModel { get; }
    }
}