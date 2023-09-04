using App.Player.Config;
using UnityEngine;

namespace App.CommonUnit.Config.Attack
{
    [CreateAssetMenu(menuName = "ScriptableObjects/PlayerConfig", fileName = "PlayerConfig")]
    public class PlayerConfigSO : ScriptableObject
    {
        [SerializeField] private PlayerConfig _playerConfig;

        public PlayerConfig Config => _playerConfig;
    }
}