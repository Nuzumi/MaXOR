using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maxor.ContentGenerator
{
    public class StageGenerator
    {
        public void GenerateStage()
        {
            SimpleLevelGenerator lg = new SimpleLevelGenerator(75, 10);
            lg.GenerateLevel(new LevelSettings() { leafNodeCount = 5, equations = new EquationSetting[2] 
                {
                    new EquationSetting("+",3),
                    new EquationSetting("-",2)
                }
            });
        }
    }
}

