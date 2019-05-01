using System;
using System.Collections.Generic;
using System.Threading;

namespace Maxor.Tools
{
    public abstract class Pool<T> : AbstractPool, IDisposable where T : Pool<T>, new()
    {
        public static int inUse = 0;
        public static int inStack = 0;
        protected static readonly Stack<T> Stack = new Stack<T>(32);

#if UNITY_EDITOR
        static Thread CreationThread;
#endif
        protected abstract void OnDestroy();

        public static T Create()
        {
#if UNITY_EDITOR
            CreationThread = Thread.CurrentThread;
#endif
            T pooledObject = null;
            if (Stack.Count > 0)
            {
                pooledObject = Stack.Pop();
                --inStack;
            }
            else
            {
                pooledObject = new T();
            }
            ++inUse;
            pooledObject.disposed = false;
            return pooledObject;
        }

        public void Dispose()
        {
#if UNITY_EDITOR
            if (Thread.CurrentThread != CreationThread)
                return;
#endif
            if (disposed)
                return;

            OnDestroy();
            disposed = true;
            Stack.Push((T)this);
            --inUse;
            ++inStack;
        }

        ~Pool()
        {
            this.Dispose();
        }
    }

    // this class is here for easier Pool access via reflection
    public abstract class AbstractPool
    {
        protected bool disposed = true;
        public bool Disposed => disposed;
    }
}
