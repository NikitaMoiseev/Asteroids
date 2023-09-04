using App.CommonUnit.Config;
using System.Collections;
using System.Collections.Generic;
using Unit.Model;
using UnityEngine;

namespace App.CommonUnit.Model
{
    public class UnitRotateModel : IRotateModel
    {
        public float RotateSpeed { get; }
        public float RotateAngleValue { get; private set; }

        public UnitRotateModel(UnitConfig config)
        {
            RotateSpeed = config.RotateSpeed;
        }

        public void SetRotateDirection(float direction)
        {
            var directionNormalized = Mathf.Clamp(direction, -1, 1);
            RotateAngleValue = directionNormalized * RotateSpeed;
        }
    }
}