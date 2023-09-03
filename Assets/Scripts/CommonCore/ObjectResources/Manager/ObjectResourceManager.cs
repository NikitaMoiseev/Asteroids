using System.Collections.Generic;
using ObjectResources.Model;
using ObjectResources.Component;
using UnityEngine;
using System.Linq;

namespace ObjectResources.Manager
{
    public class ObjectResourceManager
    {
        private const string OBJECT_PREFABS_PATH_ROOT = "Content/";

        private readonly Dictionary<string, ResourceModel> _resources = new Dictionary<string, ResourceModel>();

        public ObjectResourceManager()
        {
            _resources = LoadResources();
        }

        public IEnumerable<ResourceModel> GetAllResources() => _resources.Values;

        public ResourceModel GetResource(string objectId)
        {
            if (!_resources.ContainsKey(objectId))
            {
                throw new KeyNotFoundException($"Resource prefab not found with objectId:= {objectId}");
            }
            return _resources[objectId];
        }

        public ResourceModel FindPrefab(string objectId) 
        {
            return !_resources.ContainsKey(objectId) ? null : _resources[objectId];
        }

        private Dictionary<string, ResourceModel> LoadResources()
        {
            var resources = Resources.LoadAll<ResourceObject>(OBJECT_PREFABS_PATH_ROOT);
            return resources.ToDictionary(it => it.GetResourceModel.ObjectId, it => it.GetResourceModel);
        }
    }
}