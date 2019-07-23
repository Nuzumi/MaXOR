using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Maxor.Model;
using Maxor.ContentGenerator;

namespace Maxor.EditorScripts
{
    [CustomEditor(typeof(LevelsContent))]
    public class LevelsContentEditor : Editor
    {
        public Stage stage;

        private StageGenerator sg = new StageGenerator();

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            stage = (Stage)EditorGUILayout.EnumPopup("Stage to generate:", stage);

            if (GUILayout.Button("GenerateLevels"))
            {
                sg.GenerateStage();
            }
        }
    }

    public enum Stage { Stage1, Stage2, Stage3}
}

