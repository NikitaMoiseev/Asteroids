using CommonComponents;
using System.Collections;
using System.Collections.Generic;
using Unit.Model;
using UnityEngine;

namespace App.Enemy.Components
{
    public class EnemyCollisionAttack : MonoBehaviour, IInitializable<IUnitModel>
    {
        private IAttackModel _attackModel;
        public void Init(IUnitModel model)
        {
            _attackModel = model.AttackModel;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            _attackModel.Attack(transform.position - collision.transform.position, transform);
        }
    }
}