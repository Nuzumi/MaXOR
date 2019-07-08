using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Maxor.Utils;

namespace Maxor.EditorScripts
{
    [CustomEditor(typeof(PrefabsReferences))]
    public class PrefabReferencesEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (GUILayout.Button("Refresh"))
            {
                PrefabsReferences references = (PrefabsReferences)target;
                references.Refresh();
            }
        }
    }
}
