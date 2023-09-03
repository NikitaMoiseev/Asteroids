using System;
using System.Collections.Generic;
using ObjectPool.Component;
using ObjectPool.Wrapper;
using ObjectPool.Pool;
using UnityEngine;

namespace ObjectPool.Manager
{
    public class PoolManager : IDisposable
    {
        private readonly Dictionary<string, IObjectPool<GameObject>> _pools = new Dictionary<string, IObjectPool<GameObject>>();

        private readonly IPoolWrapper _poolWrapper;

        public PoolManager(IPoolWrapper poolWrapper)
        {
            _poolWrapper = poolWrapper;
        }

        public void Prepare(PoolObject poolObject)
        {
            if (_pools.ContainsKey(poolObject.PoolId))
            {
                throw new ArgumentException($"Object pool already prepared by pool id, id:= {poolObject.PoolId}");
            }
            _pools[poolObject.PoolId] = _poolWrapper.BuildObjectPool(
                poolObject.PoolId,
                poolObject,
                obj => OnObjectCreated(poolObject));
        }

        public bool HasPool(string poolId) => _pools.ContainsKey(poolId);

        public GameObject Get(PoolObject poolObject)
        {
            if (!_pools.ContainsKey(poolObject.PoolId))
            {
                _pools[poolObject.PoolId] = _poolWrapper.BuildObjectPool(
                    poolObject.PoolId,
                    poolObject,
                    obj => OnObjectCreated(poolObject));
            }
            return _pools[poolObject.PoolId].Get();
        }

        private void OnObjectCreated(PoolObject poolObject)
        {

        }

        public void Release(GameObject instance)
        {
            if (!instance.TryGetComponent(out PoolObject poolObject))
            {
                throw new NullReferenceException($"Error releasing gameObject to the pool, instance does't contain PoolObject, gameObject name:= {instance.name}");
            }
            Release(poolObject);
        }

        public void Release(PoolObject poolObject)
        {
            var poolId = poolObject.PoolId;
            if (!_pools.ContainsKey(poolId))
            {
                throw new NullReferenceException($"PoolObject is null by pool id:= {poolId}");
            }
            _pools[poolId].Release(poolObject.gameObject);
        }

        public void ReleaseAllActive()
        {
            foreach (var pool in _pools.Values)
                pool.ReleaseAllActive();
        }

        public void Dispose()
        {
            foreach (var pool in _pools.Values)
                pool.Dispose();
        }

        public bool HasFreeObject(string objectId)
        {
            if (!HasPool(objectId)) return false;
            return _pools[objectId].CountInactive > 0;
        }
    }
}