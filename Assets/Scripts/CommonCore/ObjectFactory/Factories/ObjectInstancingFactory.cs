using System.Collections.Generic;
using System.Linq;
using Extensions;
using ObjectFactory.Components;
using ObjectResources.Manager;
using UnityEngine;

namespace ObjectFactory.Factories
{
    public class ObjectInstancingFactory : IObjectFactory
    {
        private readonly HashSet<GameObject> _createdObjects = new HashSet<GameObject>();

        private ObjectResourceManager _objectResourceManager;

        public ObjectInstancingFactory(ObjectResourceManager objectResourceManager)
        {
            _objectResourceManager = objectResourceManager;
        }

        public T Create<T>(string objectId, Transform container = null) where T : class
        {
            var prefab = _objectResourceManager.GetResource(objectId);
            return Create<T>(prefab.Prefab, container);
        }
        public T Create<T>(GameObject prefab, Transform container = null) where T : class
        {
            return CreateObject(prefab, container).RequireComponent<T>();
        }

        public T Create<T>(Component prefabComponent, Transform container = null) where T : class
        {
            return Create<T>(prefabComponent.gameObject, container);
        }

        public void Destroy(GameObject instance)
        {
            _createdObjects.Remove(instance);
            GameObject.Destroy(instance);
        }
        
        private GameObject CreateObject(GameObject prefab, Transform container = null)
        {
            var createdGameObject = GameObject.Instantiate(prefab, container?.transform);
            createdGameObject.GetComponent<Destroyer>().Init(this);
            _createdObjects.Add(createdGameObject);
            return createdGameObject;
        }
        public void DestroyAllObjects()
        {
            _createdObjects.Where(it => it != null).ForEach(Destroy);
            _createdObjects.Clear();
        }
    }
}