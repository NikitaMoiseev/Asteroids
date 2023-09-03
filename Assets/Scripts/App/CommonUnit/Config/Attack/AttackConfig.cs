using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace App.CommonUnit.Config.Attack
{
    [Serializable]
    public class AttackConfig
    {
        [SerializeField] private string _id;
        [SerializeField] private string _projectileId;
        [SerializeField] private float _attackInterval;
        [SerializeField] private float _hitDamage;

        public string Id => _id;
        public string ProjectileId => _projectileId;
        public float AttackInterval => _attackInterval;
        public float HitDamage => _hitDamage;
    }
}