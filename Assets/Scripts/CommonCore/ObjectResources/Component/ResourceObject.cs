using System;
using ObjectResources.Model;
using UnityEngine;

namespace ObjectResources.Component
{
    [DisallowMultipleComponent]
    public class ResourceObject : MonoBehaviour
    {
        [SerializeField] private string _objectId;

        public void Reset() => _objectId = gameObject.name;
        public ResourceModel GetResourceModel => new ResourceModel(_objectId, gameObject);
    }
}