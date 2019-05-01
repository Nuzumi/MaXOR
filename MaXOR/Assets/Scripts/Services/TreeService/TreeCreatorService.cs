using MaXOR.Model;
using MaXOR.Model.Tree;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MaXOR.Services.Tree
{
    public interface ITreeCreatorService
    {
        void Setup();
        AbstractNode GetTreeRoot(string json);
        AbstractNode GetTreeRoot(JSONNode node);
    }

    public class TreeCreatorService : ITreeCreatorService
    {
        private Dictionary<string, IEquation> equations = new Dictionary<string, IEquation>();

        public void Setup()
        {
            SetupEquations();
        }

        public AbstractNode GetTreeRoot(string json)
        {
            return GetTreeRoot(Deserialize(json));
        }

        public AbstractNode GetTreeRoot(JSONNode node)
        {
            RootNode rootNode = new RootNode();
            MathematicNode mathematicNode = new MathematicNode();
            rootNode.Setup(mathematicNode, node.value);
            mathematicNode.SetParent(rootNode);
            mathematicNode.SetChildren(CreateNode(mathematicNode, node.children[0]));
            return rootNode;
        }

        private List<Node> CreateNode(MathematicNode node, JSONNode creatorNode)
        {
            node.Equation = equations[creatorNode.equation];
            List<MathematicNode> matNodes = new List<MathematicNode>();
            List<LeafNode> leafNodes = new List<LeafNode>();

            for(int i =0; i < creatorNode.children.Length; i++)
            {
                if(creatorNode.children[i].children != null && creatorNode.children[i].children.Length > 0)
                {
                    MathematicNode mathematicNode = new MathematicNode();
                    mathematicNode.SetParent(node);
                    mathematicNode.SetChildren(CreateNode(mathematicNode, creatorNode.children[i]));
                    matNodes.Add(mathematicNode);
                }
                else
                {
                    LeafNode leafNode = new LeafNode();
                    leafNode.Setup(node);
                    leafNode.SetExpectedValue(creatorNode.children[i].value);
                    leafNodes.Add(leafNode);
                }
            }

            List<Node> result = new List<Node>();
            result.AddRange(matNodes);
            result.AddRange(leafNodes);
            return result;
        }

        private JSONNode Deserialize(string json)
        {
            return JsonConvert.DeserializeObject<JSONNode>(json);
        }

        private void SetupEquations()
        {
            equations.Add("+", new Sum());
            equations.Add("*", new Multiplication());
            equations.Add("/", new Division());
            equations.Add("-", new Subtraction());
        }

    }
}

