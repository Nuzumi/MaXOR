using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MaXOR.Services.Tree
{
    public abstract class AbstractNode
    {
        public abstract void SetValue();
    }

    public abstract class Node : AbstractNode
    {
        public float? Value { get; protected set; }
        protected AbstractNode parent;

        public virtual void Setup(AbstractNode parent)
        {
            this.parent = parent;
        }
       
    }
}


