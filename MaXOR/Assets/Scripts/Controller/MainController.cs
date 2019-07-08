

using Maxor.Model.Tree;
using UnityEngine;

namespace Maxor
{
    public interface IMainController
    {
        IReferences References { get; }
        IServices Services { get; }
    }

    public class MainController : MonoBehaviour, IMainController
    {
        public IReferences References => references;
        public References references;

        public string value;

        public IServices Services { get; private set; }

        private void Start()
        {
            Services = new Services(this);

            Services.GameService.StartLevel(value);
        }

    }
}
