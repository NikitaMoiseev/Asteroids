using App.CommonUnit.Config;
using System.Collections;
using System.Collections.Generic;
using Unit.Model;
using UnityEngine;

namespace App.CommonUnit.Model
{
    public class UnitMovementModel : IMovementModel
    {
        public float MaxSpeed { get; }
        public float Acceleration { get; }
        public float BrakingAcceleration { get; }
        public Vector3 Velocity { get; private set; }

        public UnitMovementModel(UnitConfig config)
        {
            MaxSpeed = config.MaxSpeed;
            Acceleration = config.Acceleration;
            BrakingAcceleration = config.BrakingAcceleration;
        }

        public void UpdateVelocity(Vector3 direction)
        {
            if (direction != Vector3.zero)
                AddVelocity(direction.normalized * Acceleration);
            else
                AddVelocity(-Velocity.normalized * BrakingAcceleration);
        }

        private void AddVelocity(Vector3 velocity)
        {
            Velocity += velocity;
            if (Velocity.sqrMagnitude > MaxSpeed * MaxSpeed)
                Velocity = Velocity.normalized * MaxSpeed;
        }
    }
}