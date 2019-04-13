using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MaXOR.Services.Tree
{
    public class MathematicNode : Node
    {
        public IEquation Equation { get; set; }

        private List<Node> children;
        
        public void Setup(AbstractNode parent,IEquation equation, List<Node> children)
        {
            base.Setup(parent);
            Equation = equation;
            this.children = new List<Node>(children);
        }

        public override void SetValue()
        {
            if (AllValuesSet())
            {
                Value = Equation.GetResult(children.Select(child => child.Value.Value).ToArray());
                parent.SetValue();
            }
        }

        private bool AllValuesSet()
        {
            for (int i = 0; i < children.Count; i++)
                if (!children[i].Value.HasValue)
                    return false;

            return true;
        }
        
    }

}

