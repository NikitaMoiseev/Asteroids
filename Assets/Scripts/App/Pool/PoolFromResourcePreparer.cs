using CommonCore.ObjectPool.Component;
using CommonCore.ObjectPool.Manager;
using CommonCore.ObjectResources.Manager;
using CommonCore.Extensions;
using System.Linq;

namespace App.Pool
{
    public static class PoolFromResourcePreparer
    {
        public static void Prepare(PoolManager poolManager, ObjectResourceManager objectResourceManager)
        {
            objectResourceManager.GetAllResources()
                .Select(it => it.Prefab.GetComponent<PoolObject>())
                .Where(it => it != null && it.PreparePoolOnInitScene)
                .ForEach(it => poolManager.Prepare(it));
        }
    }
}