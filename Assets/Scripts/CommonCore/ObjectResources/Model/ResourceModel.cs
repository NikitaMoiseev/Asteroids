using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CommonCore.ObjectResources.Model
{
    [Serializable]
    public class ResourceModel
    {
        public string ObjectId { get; private set; }
        public GameObject Prefab { get; private set; }

        public ResourceModel(string objectId, GameObject prefab)
        {
            ObjectId = objectId;
            Prefab = prefab;
        }
    }
}