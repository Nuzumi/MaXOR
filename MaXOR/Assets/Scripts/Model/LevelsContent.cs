using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maxor.Model
{
    [CreateAssetMenu(fileName = "LevelsContent", menuName = "Content/LevelsContent")]
    public class LevelsContent : ScriptableObject
    {
        [SerializeField]
        public List<StageContent> stages;
    }
}

