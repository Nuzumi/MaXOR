using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MaXOR.Services.Tree
{
    public class RootNode : AbstractNode
    {
        private Node child;

        public void Setup(Node child, float value)
        {
            this.child = child;
            Value = value;
        }

        public override void SetValue()
        {
            if (child.Value.Value == Value)
                Debug.Log("ok");
        }
    }
}

