using ObjectResources.Manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace App
{
    public class GameApplication : MonoBehaviour
    {
        [SerializeField] private FactoryManager.FactoryManager _factoryManager;
        private ObjectResourceManager _resourceManager;

        private void Awake()
        {
            _resourceManager = new ObjectResourceManager();
            _factoryManager.Init(_resourceManager);
        }

        private void OnDestroy()
        {
            _factoryManager.Dispose();
        }
    }
}