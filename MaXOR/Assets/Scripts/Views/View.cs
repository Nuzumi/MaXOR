using Maxor.Views;
using UnityEngine;

namespace Maxor.Model.View
{
    public interface IView
    {
        bool IsShown { get; }

        void Show();
        void Hide();
    }

    public abstract class View<T> : IView where T : MonoBehaviour
    {
        protected T refs;
        protected GameObject go;

        protected readonly IServices services;
        protected readonly IViews views;
        
        public View(IServices services, IViews views)
        {
            this.services = services;
            this.views = views;

            go = services.PrefabsService.Get(null, GetType()); 
            //TODO TRANSFORM
            go.SetActive(false);
            refs = refs.GetComponent<T>();
        }
        
        public bool IsShown { get; set; }

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