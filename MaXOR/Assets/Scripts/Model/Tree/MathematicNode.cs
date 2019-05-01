using MaXOR.Services.Tree;
using System.Collections.Generic;
using System.Linq;

namespace MaXOR.Model.Tree
{
    public class MathematicNode : Node
    {
        public IEquation Equation { get; set; }
        public List<Node> Children => children;

        private List<Node> children;
        
        public void Setup(AbstractNode parent,IEquation equation, List<Node> children)
        {
            Setup(parent);
            Equation = equation;
            this.children = new List<Node>(children);
        }

        public void SetParent(AbstractNode parent)
        {
            Setup(parent);
        }

        public void SetChildren(List<Node> nodes)
        {
            children = new List<Node>(nodes);
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

