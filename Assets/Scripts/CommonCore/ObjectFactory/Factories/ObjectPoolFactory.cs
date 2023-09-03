using System;
using System.ComponentModel;
using Extensions;
using ObjectFactory.Components;
using ObjectPool.Component;
using ObjectPool.Manager;
using ObjectPool.Pool;
using ObjectResources.Manager;
using UnityEngine;
using UnityEngine.Assertions;

namespace ObjectFactory.Factories
{
    public class ObjectPoolFactory : IObjectFactory
    {
        private PoolManager _poolManager;
        private ObjectResourceManager _objectResourceManager;

        public ObjectPoolFactory(PoolManager poolManager, ObjectResourceManager objectResourceManager)
        {
            _poolManager = poolManager;
            _objectResourceManager = objectResourceManager;
        }

        public T Create<T>(string objectId, Transform container = null) where T : class
        {
            var prefab = _objectResourceManager.GetResource(objectId);
            return Create<T>(prefab.Prefab, container);
        }

        public T Create<T>(GameObject prefab, Transform container = null) where T : class
        {
            return GetNewObject(GetPoolObjectComponent(prefab), container).RequireComponent<T>();
        }

        public void Destroy(GameObject instance)
        {
            _poolManager.Release(instance);
        }

        public void DestroyAllObjects()
        {
            _poolManager.ReleaseAllActive();
        }

        public bool HasFreeObject(string objectId) => _poolManager.HasFreeObject(objectId);

        private GameObject GetNewObject(PoolObject poolObject, Transform container = null)
        {
            var resultObject = _poolManager.Get(poolObject);
            resultObject.GetComponent<Destroyer>().Init(this);
            if (container != null) {
                resultObject.transform.SetParent(container);
            }
            return resultObject;
        }

        private PoolObject GetPoolObjectComponent(GameObject prefab)
        {
            var poolObject = prefab.GetComponent<PoolObject>();
            Assert.IsNotNull(poolObject, $"{prefab.name} gameObject is missing {typeof(PoolObject).Name} component in hierarchy");
            return poolObject;
        }
    }
}