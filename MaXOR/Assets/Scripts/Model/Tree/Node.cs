using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maxor.Model.Tree
{
    public abstract class AbstractNode
    {
        public float? Value { get; protected set; }
        public abstract void SetValue();
    }

    public abstract class Node : AbstractNode
    {
        public bool HasChildren => Children != null;
        public abstract List<Node> Children { get; }
        protected AbstractNode parent;

        public virtual void Setup(AbstractNode parent)
        {
            this.parent = parent;
            Value = null;
        }

        public abstract override string ToString();
    }
}


