using Maxor.Service;

namespace Maxor
{
    public interface IServices
    {
        IPrefabsService PrefabsService { get; }
    }

    public class Services : IServices
    {
        public IPrefabsService PrefabsService { get; private set; }

        public Services(MainController controller)
        {
            PrefabsService = new PrefabsService(this, controller.References.PrefabsReferences);
        }
    }
}
