using System;
using UnityEngine;
using ObjectPool.Component;
using ObjectPool.Pool;

namespace ObjectPool.Wrapper
{
    public class CommonPoolWrapper : MonoBehaviour, IPoolWrapper
    {
        [SerializeField]
        private Transform _poolRoot;

        public IObjectPool<GameObject> BuildObjectPool(
            string poolName,
            PoolObject poolObject,
            Action<GameObject> onObjectCreated)
        {
            return new ObjectPool<GameObject>(poolName,
                () => OnCreateObject(poolObject.gameObject, onObjectCreated),
                OnGetFromPool,
                OnReleaseToPool,
                OnDestroyObject,
                poolObject.PoolParams);
        }

        private GameObject OnCreateObject(GameObject prefab, Action<GameObject> onObjectCreated)
        {
            var createdGameObject = Instantiate(prefab, _poolRoot);
            createdGameObject.transform.SetPositionAndRotation(Vector3.zero, Quaternion.identity);
            createdGameObject.gameObject.SetActive(false);
            onObjectCreated.Invoke(createdGameObject);
            return createdGameObject;
        }
        private void OnGetFromPool(GameObject instance)
        {
            instance.transform.SetParent(_poolRoot);
            instance.transform.SetPositionAndRotation(Vector3.zero, Quaternion.identity);
            instance.gameObject.SetActive(true);
        }
        private void OnReleaseToPool(GameObject instance)
        {
            instance.transform.SetParent(_poolRoot);
            instance.gameObject.SetActive(false);
        }

        private void OnDestroyObject(GameObject instance)
        {
            Destroy(instance.gameObject);
        }
    }
}