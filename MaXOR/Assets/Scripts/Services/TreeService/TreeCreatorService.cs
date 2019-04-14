using MaXOR.Model;
using MaXOR.Model.Tree;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MaXOR.Services.Tree
{
    public class TreeCreatorService
    {
        private Dictionary<string, IEquation> equations = new Dictionary<string, IEquation>();

        public void Setup()
        {
            SetupEquations();
        }

        public AbstractNode GetTreeRoot(string json)
        {

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

