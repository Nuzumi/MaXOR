using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maxor.Model
{
    [Serializable]
    [CreateAssetMenu(fileName = "stage content", menuName = "Content/StageContent")]
    public class StageContent : ScriptableObject
    {
        public JSONLevelValues[] levels;
    }
}
