﻿

using UnityEngine;

namespace Maxor
{
    public interface IMainController
    {
        IReferences References { get; }
        IServices Services { get; }
        Canvas Canva { get; }
    }

    public class MainController : MonoBehaviour, IMainController
    {
        public IReferences References => references;
        public References references;

        public Canvas Canva => canva;
        public Canvas canva;

        public IServices Services { get; private set; }

        private void Start()
        {
            Services = new Services(this);
        }

    }
}
