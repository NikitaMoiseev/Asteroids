using CommonComponents;
using Unit.Model;
using UnityEngine;

namespace App.Enemy.Components
{
    public class EnemyCollisionAttack : MonoBehaviour, IInitializable<Unit.Unit>
    {
        private IAttackModel _attackModel;
        public void Init(Unit.Unit data)
        {
            _attackModel = data.Model.AttackModel;
        }

        private void Update() => _attackModel.OnTick();

        private void OnTriggerEnter2D(Collider2D collision)
        {
            _attackModel.Attack(transform.position - collision.transform.position, transform);
        }
    }
}