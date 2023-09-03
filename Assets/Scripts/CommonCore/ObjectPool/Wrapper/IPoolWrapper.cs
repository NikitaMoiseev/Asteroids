using CommonCore.ObjectPool.Component;
using System;
using UnityEngine;

namespace CommonCore.ObjectPool.Wrapper
{
    public interface IPoolWrapper
    {
        public IObjectPool<GameObject> BuildObjectPool(
            string poolName,
            PoolObject poolObject,
            Action<GameObject> onObjectCreated);
    }
}