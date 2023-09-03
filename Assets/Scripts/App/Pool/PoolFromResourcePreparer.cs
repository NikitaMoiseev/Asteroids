using ObjectPool.Component;
using ObjectPool.Manager;
using ObjectResources.Manager;
using Extensions;
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