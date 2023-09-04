using UnityEngine;

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
        void Attack(Vector3 direaction, Transform launchTransform);
    }
}