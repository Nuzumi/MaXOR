using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MaXOR.Services.Tree
{
    public class LeafNode : Node
    {
        public void SetLeafValue(float value)
        {
            Value = value;
        }

        public override void SetValue()
        {
            parent.SetValue();
        }
    }
}

