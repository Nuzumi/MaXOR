using Maxor.Views;
using UnityEngine;

namespace Maxor.Model.View
{
    public abstract class Element<T> : IView where T : MonoBehaviour
    {
        protected T refs;
        protected GameObject go;
        protected readonly IServices Services;
        protected readonly IViews Views;

        protected Element(IServices services, IViews views, Transform parent)
        {
            Services = services;
            Views = views;
            go = Services.PrefabsService.Get(parent, GetType());
            refs = go.GetComponent<T>();
        }

        public bool IsShown { get; private set; }

        public void Show()
        {
            if (IsShown)
                return;

            IsShown = true;
            go.SetActive(true);
        }

        public void Hide()
        {
            if (!IsShown)
                return;

            IsShown = false;
            go.SetActive(false);
        }
    }
}