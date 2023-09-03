using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CommonCore.ObjectPool.Component
{
    [DisallowMultipleComponent]
    public class PoolObject : MonoBehaviour
    {
        [SerializeField] private string _poolId;
        [SerializeField] private bool _preparePoolOnInitScene = true;
        [SerializeField] private PoolParams _poolParams;

        public void Reset() => _poolId = gameObject.name;
        public string PoolId => _poolId;
        public bool PreparePoolOnInitScene => _preparePoolOnInitScene;
        public PoolParams PoolParams => _poolParams;
    }
}