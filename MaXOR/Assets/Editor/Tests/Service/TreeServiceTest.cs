using System.Collections;
using System.Collections.Generic;
using Maxor.Model;
using Maxor.Model.Tree;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Maxor.Services.Tree
{
    public class TreeServiceTest
    {
        private TreeCreatorService service;
        private JSONNode node;

        [SetUp]
        public void SetUp()
        {
            service = new TreeCreatorService();
            service.Setup();
            SetupJsonNode();
        }

        #region SetUp

        private void SetupJsonNode()
        {
            JSONNode rootNode = new JSONNode() { value = 8};
            JSONNode matNode = new JSONNode() { equation = "+" };
            rootNode.children = new JSONNode[] { matNode };
            JSONNode leafNode = new JSONNode() { value = 2 };
            JSONNode matChild = new JSONNode() { equation = "*" };
            matNode.children = new JSONNode[] { leafNode, matChild };
            JSONNode matChild1 = new JSONNode() { value = 2 };
            JSONNode matChild2 = new JSONNode() { value = 3 };
            matChild.children = new JSONNode[] { matChild1, matChild2 };
            node = rootNode;
        }

        #endregion


        [Test]
        public void GetTreeRoot_Test()
        {
            RootNode root = service.GetTreeRoot(node) as RootNode;

            Assert.AreEqual(8, root.Value);
            Assert.NotNull((root as RootNode).Child);

            MathematicNode matNode = (root as RootNode).Child as MathematicNode;
            Assert.IsInstanceOf<Sum>(matNode.Equation);
            Assert.AreEqual(2, matNode.Children.Count);

            LeafNode leaf = matNode.Children[1] as LeafNode;
            Assert.AreEqual(2, leaf.ExpectedValue);

            MathematicNode matNode2 = matNode.Children[0] as MathematicNode;
            Assert.IsInstanceOf<Multiplication>(matNode2.Equation);
            Assert.AreEqual(2, matNode2.Children.Count);

            LeafNode leaf1 = matNode2.Children[0] as LeafNode;
            Assert.AreEqual(2, leaf1.ExpectedValue);

            LeafNode leaf2 = matNode2.Children[1] as LeafNode;
            Assert.AreEqual(3, leaf2.ExpectedValue);
        }
    }
}
