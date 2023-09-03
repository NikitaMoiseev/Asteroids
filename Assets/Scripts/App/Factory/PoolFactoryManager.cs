using App.Pool;
using ObjectFactory;
using ObjectFactory.Factories;
using ObjectPool.Manager;
using ObjectPool.Wrapper;
using ObjectResources.Manager;
using UnityEngine;

namespace App.Factory
{
    public class PoolFactoryManager : FactoryManager
    {
        [SerializeField] private CommonPoolWrapper _poolWrapper;

        private PoolManager _poolManager;

        protected override IObjectFactory InitFactory(ObjectResourceManager objectResourceManager)
        {
            _poolManager = new PoolManager(_poolWrapper);
            PoolFromResourcePreparer.Prepare(_poolManager, objectResourceManager);
            return new ObjectPoolFactory(_poolManager, objectResourceManager);
        }

        public override void Dispose()
        {
            base.Dispose();
            _poolManager.Dispose();
        }
    }
}
