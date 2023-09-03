using UnityEngine;

namespace Unit.Model
{
    public interface IMovementModel
    {
        float MaxSpeed { get; }
        Vector3 Velocity { get; }
        float RotateSpeed { get; }

        void AddVelocity(Vector3 velocity);
        void SetRotateSpeed(float speed);
    }
}