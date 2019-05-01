using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MaXOR.Model.Tree
{
    public class LeafNode : Node
    {
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
    }
}

