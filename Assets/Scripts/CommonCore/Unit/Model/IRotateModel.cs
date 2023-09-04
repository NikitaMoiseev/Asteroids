namespace Unit.Model
{
    public interface IRotateModel
    {
        float RotateSpeed { get; }
        float RotateAngleValue { get; }

        void SetRotateDirection(float direction);
    }
}