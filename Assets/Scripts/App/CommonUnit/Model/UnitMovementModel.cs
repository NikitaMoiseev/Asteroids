using System.Collections;
using System.Collections.Generic;
using Unit.Model;
using UnityEngine;

namespace App.CommonUnit.Model
{
    public class UnitMovementModel : IMovementModel
    {
        public float MaxSpeed { get; }
        public Vector3 Velocity { get; private set; }
        public float RotateSpeed { get; private set; }

        public UnitMovementModel(float maxSpeed)
        {
            MaxSpeed = maxSpeed;
            Velocity = Vector3.zero;
            RotateSpeed = 0;
        }

        public void AddVelocity(Vector3 velocity)
        {
            Velocity += velocity;
            if(velocity.sqrMagnitude > MaxSpeed * MaxSpeed)
                Velocity = Velocity.normalized * MaxSpeed;
        }

        public void SetRotateSpeed(float speed)
        {
            RotateSpeed = speed;
        }
    }
}