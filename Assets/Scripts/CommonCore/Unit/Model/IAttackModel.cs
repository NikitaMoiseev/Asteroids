﻿using UnityEngine;

namespace Unit.Model
{
    public interface IAttackModel
    { 
        string Name {  get; }
        string ProjectileId { get; }
        float AttackInterval { get; }
        float HitDamage { get; }
        float ReloadTimerValue { get; }
        bool IsReady { get; }
        int ChargesCount { get; }
        int ChargesMaxCount { get; }
        void Attack(Vector3 direction, Transform launchTransform);
        void OnTick();
    }
}