using Maxor.Model.Tree;
using Maxor.Service;
using Maxor.Service.TreeService;

namespace Maxor
{
    public interface IServices
    {
        IPrefabsService PrefabsService { get; }
        ITreeCreatorService TreeCreatorService { get; }
        IUiTreeCreator UiTreeCreator { get; }
        IInputNumberDropService InputNumberDropService { get; }
        ILineRendererCreatorService LineRendererCreatorService { get; }
        IGameService GameService { get; }
    }

    public class Services : IServices
    {
        public IPrefabsService PrefabsService { get; private set; }
        public ITreeCreatorService TreeCreatorService { get; private set; }
        public IUiTreeCreator UiTreeCreator { get; private set; }
        public IInputNumberDropService InputNumberDropService { get; private set; }
        public ILineRendererCreatorService LineRendererCreatorService { get; private set; }
        public IGameService GameService { get; set; }

        public Services(MainController controller)
        {
            PrefabsService = new PrefabsService(this, controller.References.PrefabsReferences);

            TreeCreatorService = new TreeCreatorService();
            TreeCreatorService.Setup();

            UiTreeCreator = new UiTreeCreator(this,controller.references.worldReferences.TreeCanvas.transform);
            InputNumberDropService = new InputNumberDropService();
            LineRendererCreatorService = new LineRendererCreatorService(this ,controller.references.worldReferences.Canva.transform);
            GameService = new GameService(this, controller.references);
        }
    }
}
