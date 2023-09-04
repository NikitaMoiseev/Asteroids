using App.CommonUnit.Config;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Assertions;

namespace App.Enemy.Config
{
    [CreateAssetMenu(menuName = "ScriptableObjects/EnemyConfigs", fileName = "EnemyConfigs")]
    public class EnemyConfigsSO : ScriptableObject
    {
        [SerializeField] private List<UnitConfig> _enemyConfigs;
        private Dictionary<string, UnitConfig> _enemyConfigsDict;

        private Dictionary<string, UnitConfig> EnemyConfigsDict =>
            _enemyConfigsDict ??= _enemyConfigs.ToDictionary(it => it.Id, it => it);

        public UnitConfig GetConfig(string id)
        {
            Assert.IsTrue(EnemyConfigsDict.ContainsKey(id), $"Enemy id: {id} not found");
            return EnemyConfigsDict[id];
        }
    }
}