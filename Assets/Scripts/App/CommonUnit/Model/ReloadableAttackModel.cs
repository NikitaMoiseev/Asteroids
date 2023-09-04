using App.CommonUnit.Config.Attack;
using Unit.Model;
using UnityEngine;

namespace App.CommonUnit.Model
{
    public abstract class ReloadableAttackModel : IAttackModel
    {
        protected float _timer;
        protected int _chargesNumber;

        public string Name { get; }
        public string ProjectileId { get; }
        public float AttackInterval { get; }
        public float HitDamage { get; }
        public float ReloadTimerValue => _timer;
        public bool IsReady => ChargesCount != 0;
        public int ChargesCount => _chargesNumber;
        public int ChargesMaxCount { get; }

        public ReloadableAttackModel(AttackConfig attackConfig)
        {
            Name = attackConfig.Id;
            ProjectileId = attackConfig.ProjectileId;
            AttackInterval = attackConfig.AttackInterval;
            HitDamage = attackConfig.HitDamage;
            ChargesMaxCount = attackConfig.ChargesMaxCount;
            _chargesNumber = 1;
        }

        public void Attack(Vector3 direction, Transform launchTransform)
        {
            if (!IsReady)
                return;
            OnAttack(direction, launchTransform);
        }

        protected abstract void OnAttack(Vector3 direction, Transform launchTransform);

        public virtual void OnTick()
        {
            if (IsReady)
                return;

            _timer += Time.deltaTime;
            if(_timer > AttackInterval)
            {
                _chargesNumber++;
                _timer = 0;
            }
        }
    }
}