using System;
using UnityEngine;

namespace App.CommonUnit.Config
{
    [Serializable]
    public class UnitConfig
    {
        [SerializeField] private string _id;
        [Header("Health")]
        [SerializeField] private float _maxHealth;
        [Header("Movement")]
        [SerializeField] private float _maxSpeed;
        [SerializeField] private float _acceleration;
        [SerializeField] private float _brakingAcceleration;
        [SerializeField] private float _rotateSpeed;
        [Header("Attack")]
        [SerializeField] private string _attackId;

        public string Id => _id;
        public float MaxHealth => _maxHealth;
        public float MaxSpeed => _maxSpeed;
        public float Acceleration => _acceleration;
        public float BrakingAcceleration => _brakingAcceleration;
        public float RotateSpeed => _rotateSpeed;
        public string AttackId => _attackId;
    }
}