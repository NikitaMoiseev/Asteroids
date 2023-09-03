using ObjectResources.Manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using App.Factory;
using App.Player.Manager;
using App.CommonUnit.Config.Attack;

namespace App
{
    public class GameApplication : MonoBehaviour
    {
        [SerializeField] private FactoryManager _factoryManager;
        [Header("Configs")]
        [SerializeField] private AttackConfigsSO _attackConfigs;

        private ObjectResourceManager _resourceManager;
        private PlayerManager _playerManager;

        private void Awake()
        {
            _resourceManager = new ObjectResourceManager();
            _playerManager = new PlayerManager();
            _factoryManager.Init(_resourceManager);
            _playerManager.SpawnPlayer(_factoryManager.Factory, _attackConfigs);
        }

        private void OnDestroy()
        {
            _factoryManager.Dispose();
        }
    }
}