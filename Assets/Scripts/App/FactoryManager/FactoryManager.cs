using ObjectFactory;
using ObjectResources.Manager;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace App.FactoryManager
{
    public abstract class FactoryManager : MonoBehaviour, IDisposable
    {
        private IObjectFactory _objectFactory;

        public IObjectFactory Factory => _objectFactory;

        protected abstract IObjectFactory InitFactory(ObjectResourceManager objectResourceManager);

        public void Init(ObjectResourceManager objectResourceManager)
        {
            Assert.IsNull(_objectFactory, "Factory has been initialized");
            _objectFactory = InitFactory(objectResourceManager);
        }

        public virtual void Dispose()
        {
            _objectFactory?.DestroyAllObjects();
            _objectFactory = null;
        }
    }
}