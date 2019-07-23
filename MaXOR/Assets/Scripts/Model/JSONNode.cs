using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Maxor.Model
{
    [Serializable]
    public class JSONNode
    {
        public int value;
        public string equation;
        public JSONNode[] children;
    }

    [Serializable]
    public class JSONLevelValues
    {
        public JSONNode rootNode;
        public int[] inputNumbers;
    }
}

