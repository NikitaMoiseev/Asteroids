using App.CommonUnit.Config;
using System;
using UnityEngine;

namespace App.Player.Config
{
    [Serializable]
    public class PlayerConfig : UnitConfig
    {
        [SerializeField] private string _secondAttackId;

        public string SecondAttackId => _secondAttackId;
    }
}