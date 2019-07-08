using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Maxor.Utils
{
    public interface IPrefabsReferences
    {
        List<GameObject> Prefabs { get; }
        string[] Paths { get; }
    }

    [CreateAssetMenu(fileName = "References", menuName = "Refs/PrefabReferences")]
    public class PrefabsReferences : ScriptableObject, IPrefabsReferences
    {

        public List<GameObject> Prefabs => prefabs;
        public string[] Paths => paths;

        [SerializeField]
        [Header("PREFABS")]
        public List<GameObject> prefabs;
        
        [HideInInspector]
        public string[] paths;
        
#if UNITY_EDITOR
        
        public void Refresh()
        {
            paths = RefreshAndCreatePaths(prefabs);
        }

        string[] RefreshAndCreatePaths<T>(List<T> list) where T : Object
        {
            RemoveNulls(list);
            list.RemoveDuplicates();
            SortByName(list);
            string[] newPaths = CreatePaths(list);

            if (list.Count != newPaths.Length)
                Debug.LogException(new UnityException("List: " + list.Count + "   Paths: " + paths.Length));
            else
                Debug.Log("Validation succesed");
            return newPaths;
        }

        void RemoveNulls<T>(List<T> list) where T : Object
        {
            list.RemoveAll(c => c == null);
        }

        void SortByName<T>(List<T> list) where T : Object
        {
            list.Sort((go1, go2) => string.Compare(go1.name, go2.name));
        }

        string[] CreatePaths<T>(List<T> list) where T : Object
        {
            string[] newPaths = new string[list.Count];
            for (int i = 0; i < list.Count; i++)
            {
                string path = AssetDatabase.GetAssetPath(list[i].GetInstanceID());
                path = path.Replace("Assets/Static/", "").Replace(".prefab", "");
                newPaths[i] = path;
            }
            return newPaths;
        }
#endif
    }
}