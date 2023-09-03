using ObjectFactory;
using ObjectFactory.Factories;
using ObjectResources.Manager;

namespace App.FactoryManager
{
    public class InstancingFactoryManager : FactoryManager
    {
        protected override IObjectFactory InitFactory(ObjectResourceManager objectResourceManager)
        {
            return new ObjectInstancingFactory(objectResourceManager);
        }
    }
}