namespace Unit.Model
{
    public interface IUnitModel
    {
        IHealthModel HealthModel { get; }
        IMovementModel MovementModel { get; }
        IAttackModel AttackModel { get; }
    }
}