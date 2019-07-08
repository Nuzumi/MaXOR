using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maxor.Model.Tree
{
    public class LeafNode : Node
    {
        public override List<Node> Children => null;
        public float ExpectedValue => expectedValue;

        private float expectedValue;

        public void SetExpectedValue(float value)
        {
            expectedValue = value;
        }

        public override void SetValue()
        {
            parent.SetValue();
        }

        public void SetBaseValue(float value)
        {
            Value = value;
            SetValue();
        }

        public override string ToString()
        {
            return "";
        }
    }
}

