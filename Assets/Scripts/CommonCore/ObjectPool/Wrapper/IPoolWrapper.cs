using ObjectPool.Component;
using ObjectPool.Pool;
using System;
using UnityEngine;

namespace ObjectPool.Wrapper
{
    public interface IPoolWrapper
    {
        public IObjectPool<GameObject> BuildObjectPool(
            string poolName,
            PoolObject poolObject,
            Action<GameObject> onObjectCreated);
    }
}