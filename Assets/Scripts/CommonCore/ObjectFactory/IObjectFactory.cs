using UnityEngine;

namespace ObjectFactory
{
    public interface IObjectFactory
    {
        T Create<T>(string objectId, Transform container = null) where T : class;
        void Destroy(GameObject instance);
        void DestroyAllObjects();
    }
}