using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace ObjectFactory.Components
{
    public class Destroyer : MonoBehaviour
    {
        private IObjectFactory _factory;

        public void Init(IObjectFactory objectFactory)
        {
            _factory = objectFactory;
        }

        public void Destroy()
        {
            Assert.IsNotNull(_factory, "ObjectFactory is null");
            _factory.Destroy(gameObject);
            _factory = null;
        }
    }
}