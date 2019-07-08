using Maxor.Model;
using Maxor.Model.Tree;
using Maxor.Views;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maxor.Service.TreeService
{
    public interface IUiTreeCreator
    {
        Action OnTreeFinished { get; set; }
        
        void Create(RootNode node);
    }

    public class UiTreeCreator : IUiTreeCreator
    {
        public Action OnTreeFinished { get; set; }
        
        private IServices services;
        private Transform canva;

        private const int heightDifferent = StaticConstants.nodeHeightDifference;
        private const int widthDifference = StaticConstants.nodeWidthDifference;

        public UiTreeCreator(IServices services, Transform canva)
        {
            this.services = services;
            this.canva = canva;
        }

        public void Create(RootNode node)
        {
            int treeHeight = GetThreeHeight(node.Child);
            GameObject prefabNode = services.PrefabsService.Get<NodeContainer>(canva.transform);
            NodeContainer nodeContainer = prefabNode.GetComponent<NodeContainer>();
            nodeContainer.SetText(node.ToString());
            CreateFirst(nodeContainer,node.Child, treeHeight);
        }

        private int GetThreeHeight(Node node)
        {
            if (!node.HasChildren)
                return 0;

            int[] param = new int[node.Children.Count];
            for (int i = 0; i < node.Children.Count; i++)
                param[i] = GetThreeHeight(node.Children[i]);

            return 1 + Mathf.Max(param);
        }

        private void CreateFirst(NodeContainer parent, Node treeNode,int treeHight)
        {
            GameObject prefabNode = services.PrefabsService.Get<NodeContainer>(parent.transform);
            prefabNode.transform.localPosition = new Vector3(0, -heightDifferent);
            NodeContainer nodeContainer = prefabNode.GetComponent<NodeContainer>();
            nodeContainer.Setup(services,parent, treeNode,this);
            Create(prefabNode, GetChildNode(treeNode, 0), treeHight, -1);
            Create(prefabNode, GetChildNode(treeNode, 1), treeHight, 1);
            nodeContainer.MinimizeTree();
            OnTreeFinished.Invoke();
        }

        private void Create(GameObject parent,Node treeNode, int treeHight,int widthMultiplier)
        {
            if (treeHight == 0 || treeNode == null)
                return;

            NodeContainer parentContainer = parent.GetComponent<NodeContainer>();
            GameObject prefabNode = services.PrefabsService.Get<NodeContainer>(parent.transform);
            NodeContainer nodeContainer = prefabNode.GetComponent<NodeContainer>();
            nodeContainer.Setup(services,parentContainer, treeNode, this);

            Create(prefabNode, GetChildNode(treeNode, 0), treeHight - 1, -1);
            Create(prefabNode, GetChildNode(treeNode, 1), treeHight - 1, 1);
        }

        private Node GetChildNode(Node node, int index)
        {
            if (node == null)
                return null;

            if (!node.HasChildren)
                return null;

            if (node.Children.Count <= index)
                return null;

            return node.Children[index];
        }


    }
}

