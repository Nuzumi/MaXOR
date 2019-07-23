using Maxor.Model.Tree;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maxor.ContentGenerator
{
    public class LevelSettings
    {
        public int leafNodeCount;
        public int spareInputNumberCount;
        public int minInputNumber;
        public int maxInputNumber;

        public EquationSetting[] equations;
    }

    public struct EquationSetting
    {
        public string equation;
        public int points;

        public EquationSetting(string equation, int points)
        {
            this.equation = equation;
            this.points = points;
        }
    }
}

