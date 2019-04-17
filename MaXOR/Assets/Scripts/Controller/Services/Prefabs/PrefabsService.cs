using Maxor.Utils;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Maxor.Service
{
    public interface IPrefabsService
    {
        GameObject Get<T>(Transform parent);
        GameObject Get(Transform parent, Type type);
        GameObject Get(string path, Transform parent);

        GameObject Instantiate(GameObject go, Transform parent, string id);

        void Store(GameObject go);
    }

    public class PrefabsService : IPrefabsService
    {
        public IPrefabsPool pool;

        private readonly IServices services;

        private readonly Dictionary<string, GameObject> cache;

        public PrefabsService(IServices services, IPrefabsReferences prefabs)
        {
            this.services = services;

            cache = new Dictionary<string, GameObject>();
            CacheObjects(prefabs);
            pool = new PrefabsPool();
        }

        private void CacheObjects(IPrefabsReferences prefabs)
        {
            for (int i = 0; i < prefabs.Prefabs.Count; i++)
                cache[prefabs.Paths[i]] = prefabs.Prefabs[i];
        }

        public GameObject Get<T>(Transform parent)
        {
            return Get(parent, typeof(T));
        }

        public GameObject Get(Transform parent, Type type)
        {
            return Get(GetPath(type), parent);
        }

        public GameObject Get(string path, Transform parent)
        {
            GameObject obj = pool.GetObject(path);
            if (obj != null)
            {
                obj.transform.SetParent(parent, false);
                return obj;
            }
            GameObject gameObject = GameObject.Instantiate(GetPrefab(path), parent);
            gameObject.name = path;
            return gameObject;
        }

        public GameObject Instantiate(GameObject go, Transform parent, string id)
        {
            GameObject obj = pool.GetObject(id);
            if (obj != null)
            {
                obj.transform.SetParent(parent, false);
                return obj;
            }
            GameObject gameObject = GameObject.Instantiate(go, parent);
            gameObject.name = id;
            return gameObject;
        }

        private GameObject GetPrefab(string path)
        {
            GameObject prefab = null;
            if (!cache.TryGetValue(path, out prefab))
                throw new UnityException("Can't find prefab of path: " + path);
            return prefab;
        }
        
        public void Store(GameObject go) => pool.SetObject(go);

        protected string GetPath(Type type)
        {
            string path = PrefabAttribute.GetPrefabPath(type);
            if (string.IsNullOrEmpty(path))
                throw new UnityException("Type of " + type.Name + " can't be pooled! No path attribute found! Try specify it's path by attribute!");
            return path;
        }
    }
}
