using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maxor.Model
{
    public class JSONNode
    {
        public int value;
        public string equation;
        public JSONNode[] children;
    }

    public class JSONLevelValues
    {
        public JSONNode rootNode;
        public int[] inputNumbers;
    }
}

