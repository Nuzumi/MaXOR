using Maxor.Model;
using Maxor.Model.Tree;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Maxor.ContentGenerator
{
    public interface ILevelGenerator
    {
        JSONLevelValues GenerateLevel(LevelSettings settings);
    }

    public class SimpleLevelGenerator : ILevelGenerator
    {
        private int chanceToConnect;
        private int chanceToConnectIncrese;

        private List<JSONNode> leafNodes;
        private List<JSONNode> nodesToConnect;
        private int notConnectedInRow;

        public SimpleLevelGenerator(int chanceToConnect, int chanceToConnectIncrese)
        {
            this.chanceToConnect = chanceToConnect;
            this.chanceToConnectIncrese = chanceToConnectIncrese;
        }

        public JSONLevelValues GenerateLevel(LevelSettings settings)
        {
            ResetState();
            GenerateLeafNodes(settings.leafNodeCount);
            ConnectNodes();
            InjectEquations(nodesToConnect[0],settings.equations);
            JSONLevelValues result = new JSONLevelValues();

            return result;
        }

        private void ResetState()
        {
            leafNodes = new List<JSONNode>();
            nodesToConnect = new List<JSONNode>();
            notConnectedInRow = 0;
        }

        private void GenerateLeafNodes(int count)
        {
            for(int i = 0; i< count; i++)
            {
                JSONNode node = new JSONNode();
                leafNodes.Add(node);
                nodesToConnect.Add(node);
            }
        }

        private void ConnectNodes()
        {
            while(nodesToConnect.Count != 1)
            {
                for(int i = 0; i < (nodesToConnect.Count - 1); i++)
                    if (CanConnect())
                    {
                        JSONNode node = new JSONNode()
                        {
                            children = new JSONNode[] { nodesToConnect[i], nodesToConnect[i+1] }
                        };
                        InsertToList(node, i);
                    }
            }
        }

        private bool CanConnect()
        {
            int randomValue = Random.Range(0, 100);
            bool canCoonect = randomValue < chanceToConnect + chanceToConnectIncrese * notConnectedInRow;

            if (canCoonect)
                notConnectedInRow = 0;
            else
                notConnectedInRow++;

            return canCoonect;
        }

        private void InsertToList(JSONNode node, int index)
        {
            List<JSONNode> result = new List<JSONNode>();
            for(int i = 0; i< nodesToConnect.Count; i++)
                if (i == index)
                {
                    result.Add(node);
                    i++;
                }
                else
                {
                    result.Add(nodesToConnect[i]);
                }

            nodesToConnect = result;
        }

        private void InjectEquations(JSONNode node, EquationSetting[] equationSetting)
        {
            if (node.children == null)
                return;

            node.equation = GetRandomEquation(equationSetting);
            for (int i = 0; i < node.children.Length; i++)
                InjectEquations(node.children[i], equationSetting);
        }

        private string GetRandomEquation(EquationSetting[] equationSetting)
        {
            int sum = equationSetting.Sum(es => es.points);
            int randomValue = Random.Range(0, sum);
            int tmpSum = 0;
            for(int i = 0; i< equationSetting.Length; i++)
            {
                tmpSum += equationSetting[i].points;

                if (randomValue < tmpSum)
                    return equationSetting[i].equation;
            }

            return equationSetting[equationSetting.Length - 1].equation;
        }

        private void SetInputNumbers(int minInputNumber, int maxInputNumber)
        {
            for (int i = 0; i < leafNodes.Count; i++)
                leafNodes[i].value = Random.Range(maxInputNumber, maxInputNumber);
        }
    }
}

