using Maxor.Views;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maxor
{
    public interface IWorldReferences
    {
        GameObject InputNumberContainer { get; }
        Canvas Canva { get; }
        Canvas TreeCanvas { get; }
        AbstractTreeContainer TreeContainer { get; }
    }

    public class WorldReferences : MonoBehaviour, IWorldReferences
    {
        [SerializeField]
        private GameObject inputNumberContainer;
        public GameObject InputNumberContainer => inputNumberContainer;

        [SerializeField]
        private Canvas canva;
        public Canvas Canva => canva;

        [SerializeField]
        private Canvas treeCanvas;
        public Canvas TreeCanvas => treeCanvas;

        [SerializeField]
        private AbstractTreeContainer treeContainer;
        public AbstractTreeContainer TreeContainer => treeContainer; 
    }
}
