using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Maxor.ContentGenerator
{
    [CreateAssetMenu(menuName = "Content/StageSettings")]
    public class StageSettings : ScriptableObject
    {
        public int levelCount;
        [Header("leaf nodes count")]
        public int minLeafNode;
        public int maxLeafNode;
        [Header("spare input number count")]
        public int minInputNumber;
        public int maxInputNumber;
        [Header("result range")]
        public int minResult;
        public int maxResult;

        [Header("Equations")]
        public int sum;
        public int multiplication;
        public int subtraction;
        public int division;
        public int factorial;
        public int element;
    }
    
}

