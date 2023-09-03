using CommonCore.ObjectPool.Manager;
using CommonCore.ObjectPool.Wrapper;
using CommonCore.ObjectResources.Manager;
using App.Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace App
{
    public class GameApplication : MonoBehaviour
    {
        [SerializeField] private CommonPoolWrapper _poolWrapper;

        private PoolManager _poolManager;
        private ObjectResourceManager _resourceManager;

        private void Awake()
        {
            _poolManager = new PoolManager(_poolWrapper);
            _resourceManager = new ObjectResourceManager();
            PoolFromResourcePreparer.Prepare(_poolManager, _resourceManager);
        }

        private void OnDestroy()
        {
            _poolManager.Dispose();
        }
    }
}