using Maxor.Model;
using Maxor.Model.Tree;
using Maxor.Service;
using Maxor.Service.TreeService;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Maxor.Utils;

namespace Maxor.Views
{
    public interface IDropable
    {
        void Drop(IInputNumber inputNumber);
    }

    [PrefabAttribute("Assets/GFX/Views/NodeView")]
    public class NodeContainer : MonoBehaviour, IDropable
    {
        public TextMeshProUGUI valueText;

        public bool HasValue => Node != null ? Node.Value.HasValue : false;
        public Node Node { get; private set; }
        public int Width => GetWidth();
        public bool IsLeaf => children.Count == 0;
        public List<NodeContainer> children;
        public RectTransform RectTransform => transform as RectTransform;
        public Vector2 RectPosition => RectTransform.anchoredPosition + (parent == null ? Vector2.zero : parent.RectPosition);

        private IInputNumber inputNumber;
        private IServices services;
        private ILineView lineRenderer;
        private NodeContainer parent;

        public void Setup(IServices services ,NodeContainer parent, Node node, IUiTreeCreator uiTreeCreator)
        {
            this.services = services;
            this.parent = parent;
            Node = node;
            children = new List<NodeContainer>();
            parent.children.Add(this);
            uiTreeCreator.OnTreeFinished += OnTreeFinishe;
            valueText.text = node.ToString();
        }

        public void SetText(string text)
        {
            valueText.text = text;
        }

        private void OnTreeFinishe()
        {
            if (IsLeaf)
                services.InputNumberDropService.Addtarget(transform, this);
            
            if(parent != null)
                lineRenderer = services.LineRendererCreatorService.CreateLine(RectTransform.anchoredPosition, parent.RectTransform.anchoredPosition, parent.transform);
        }
        

        private int GetWidth()
        {
            if (IsLeaf)
                return 1;

            return (int)children.Sum(c => c.Width);
        }

        public void MinimizeTree()
        {
            if (IsLeaf)
                return;

            if (children.Count == 1)
            {
                children[0].transform.localPosition = new Vector3(0, -StaticConstants.nodeHeightDifference);
                children[0].MinimizeTree();
                return;
            }

            MinimizeChild(children[0], -1);
            MinimizeChild(children[1], 1);
        }

        private void MinimizeChild(NodeContainer container, int direction)
        {
            container.MinimizeTree();
            int childWidth = container.Width;
            container.transform.localPosition = new Vector3(direction * childWidth * StaticConstants.nodeWidthDifference, -StaticConstants.nodeHeightDifference);
        }

        public void Drop(IInputNumber inputNumber)
        {
            if (this.inputNumber != null)
                return;

            this.inputNumber = inputNumber;
            inputNumber.Hide();
            (Node as LeafNode).SetBaseValue(inputNumber.Value);
            valueText.text = inputNumber.Value.ToString();
        }

        public void OnClick()
        {
            if (inputNumber == null)
                return;
            
            inputNumber.Release();
            inputNumber = null;
            valueText.text = "";
        }
    }
}

