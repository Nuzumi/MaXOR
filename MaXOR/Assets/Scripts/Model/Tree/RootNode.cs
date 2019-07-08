using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maxor.Model.Tree
{
    public class RootNode : AbstractNode
    {
        public MathematicNode Child => child;
        private MathematicNode child;

        public void Setup(MathematicNode child, float value)
        {
            this.child = child;
            Value = value;
        }

        public override void SetValue()
        {
            if (child.Value.Value == Value)
                Debug.Log("ok");
        }

        public override string ToString()
        {
            return Value.Value.ToString();
        }
    }
}

