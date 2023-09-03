using UnityEngine;

namespace Unit.Model
{
    public interface IMovementModel
    {
        Vector3 Velocity { get; }
        Vector3 RotateSpeed { get; }
    }
}