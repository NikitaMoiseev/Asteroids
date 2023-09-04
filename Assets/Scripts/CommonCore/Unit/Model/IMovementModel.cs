using UnityEngine;

namespace Unit.Model
{
    public interface IMovementModel
    {
        float MaxSpeed { get; }
        float Acceleration { get; }
        float BrakingAcceleration { get; }
        Vector3 Velocity { get; }

        void UpdateVelocity(Vector3 direction);
    }
}