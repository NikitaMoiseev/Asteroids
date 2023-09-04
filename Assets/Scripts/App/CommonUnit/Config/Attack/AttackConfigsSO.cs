using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Assertions;

namespace App.CommonUnit.Config.Attack
{
    [CreateAssetMenu(menuName = "ScriptableObjects/AttackConfigs", fileName = "AttackConfigs")]
    public class AttackConfigsSO : ScriptableObject
    {
        [SerializeField] private List<AttackConfig> _attackConfigs;
        private Dictionary<string, AttackConfig> _attackConfigsDict;

        private Dictionary<string, AttackConfig> AttackConfigsDict => 
            _attackConfigsDict ??= _attackConfigs.ToDictionary(it => it.Id, it => it);

        public AttackConfig GetConfig(string id)
        {
            Assert.IsTrue(AttackConfigsDict.ContainsKey(id), $"Attack id: {id} not found");
            return AttackConfigsDict[id];
        }
    }
}