using System.Collections.Generic;
using UnityEngine;

namespace Maxor.Service
{
    public interface IPrefabsPool
    {
        GameObject GetObject(string resource, bool shouldActivate = true);
        void SetObject(GameObject gameObject);

        bool IsInPool(string resource);
        int PoolCount(string resource);
    }

    public class PrefabsPool : IPrefabsPool
    {
        readonly Dictionary<string, Queue<GameObject>> pools;
        public Transform transform;

        public PrefabsPool()
        {
            pools = new Dictionary<string, Queue<GameObject>>();
            CreatePoolTransform();
        }

        public GameObject GetObject(string resource, bool shouldActivate = true)
        {
            Queue<GameObject> pool = null;
            pools.TryGetValue(resource, out pool);
            if (pool != null && pool.Count > 0)
                return DequeueGameObject(pool, shouldActivate);
            else
                return null;
        }

        public bool IsInPool(string resource)
        {
            Queue<GameObject> pool = null;
            pools.TryGetValue(resource, out pool);
            return pool != null && pool.Count > 0;
        }

        public int PoolCount(string resource)
        {
            Queue<GameObject> pool = null;
            pools.TryGetValue(resource, out pool);
            return pool != null ? pool.Count : 0;
        }

        public void SetObject(GameObject gameObject)
        {
            if (!pools.ContainsKey(gameObject.name))
                CreatePool(gameObject.name);
            ResetGameObject(gameObject);
            pools[gameObject.name].Enqueue(gameObject);
        }

        void CreatePoolTransform()
        {
            transform = new GameObject("Pool").transform;
        }

        void CreatePool(string resource)
        {
            pools.Add(resource, new Queue<GameObject>());
        }

        void ResetGameObject(GameObject go)
        {
            go.SetActive(false);
            go.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            go.transform.SetParent(transform, false);
        }

        GameObject DequeueGameObject(Queue<GameObject> pool, bool shouldActivate)
        {
            GameObject go = pool.Dequeue();
            if (shouldActivate)
                go.SetActive(true);
            return go;
        }
    }
}
