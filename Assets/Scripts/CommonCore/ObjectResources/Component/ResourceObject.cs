using System;
using CommonCore.ObjectResources.Model;
using UnityEngine;

namespace CommonCore.ObjectResources.Component
{
    [DisallowMultipleComponent]
    public class ResourceObject : MonoBehaviour
    {
        [SerializeField] private string _objectId;

        public void Reset() => _objectId = gameObject.name;
        public ResourceModel GetResourceModel => new ResourceModel(_objectId, gameObject);
    }
}