using Maxor.Tools;
using System;
using System.Collections.Generic;

namespace Maxor.Tools
{
    #region two parameters
    public interface IOptimizedEvent<T, K> : IDisposable
    {
        event Action<T, K> Event;
        void Invoke(T value1, K value2);
    }

    public class OptimizedEvent<T, K> : Pool<OptimizedEvent<T, K>>, IOptimizedEvent<T, K>
    {
        readonly List<Action<T, K>> Delegates = new List<Action<T, K>>();

        public event Action<T, K> Event { add { Delegates.Add(value); } remove { Delegates.Remove(value); } }

        public void Invoke(T value1, K value2)
        {
            for (int i = Delegates.Count - 1; i >= 0; i--)
                Delegates[i](value1, value2);
        }

        protected override void OnDestroy()
        {
            Delegates.Clear();
        }
    }

    public interface IStatefulOptimizedEvent<T, K> : IDisposable
    {
        T State1 { get; set; }
        K State2 { get; set; }
        event Action<T, K> Event;
        void Invoke();
    }

    public class StatefulOptimizedEvent<T, K> : Pool<StatefulOptimizedEvent<T, K>>, IStatefulOptimizedEvent<T, K>
    {
        readonly List<Action<T, K>> Delegates = new List<Action<T, K>>();

        public T State1 { get; set; }
        public K State2 { get; set; }

        public event Action<T, K> Event
        {
            add
            {
                Delegates.Add(value);
                value.Invoke(State1, State2);
            }

            remove
            {
                Delegates.Remove(value);
            }
        }

        public void Invoke()
        {
            for (int i = Delegates.Count - 1; i >= 0; i--)
                Delegates[i](State1, State2);
        }

        protected override void OnDestroy()
        {
            Delegates.Clear();
        }
    }
    #endregion

    #region one parameter
    public interface IOptimizedEvent<T> : IDisposable
    {
        event Action<T> Event;
        void Invoke(T value);
    }

    public class OptimizedEvent<T> : Pool<OptimizedEvent<T>>, IOptimizedEvent<T>
    {
        readonly List<Action<T>> Delegates = new List<Action<T>>();

        public event Action<T> Event { add { Delegates.Add(value); } remove { Delegates.Remove(value); } }

        public void Invoke(T value)
        {
            for (int i = Delegates.Count - 1; i >= 0; i--)
                Delegates[i](value);
        }

        protected override void OnDestroy()
        {
            Delegates.Clear();
        }
    }

    public interface IStatefulOptimizedEvent<T> : IDisposable
    {
        T State { get; set; }
        event Action<T> Event;
        void Invoke();
    }

    public class StatefulOptimizedEvent<T> : Pool<StatefulOptimizedEvent<T>>, IStatefulOptimizedEvent<T>
    {
        readonly List<Action<T>> Delegates = new List<Action<T>>();

        public T State { get; set; }

        public event Action<T> Event
        {
            add
            {
                Delegates.Add(value);
                value.Invoke(State);
            }

            remove
            {
                Delegates.Remove(value);
            }
        }

        public void Invoke()
        {
            for (int i = Delegates.Count - 1; i >= 0; i--)
                Delegates[i](State);
        }

        protected override void OnDestroy()
        {
            Delegates.Clear();
        }
    }

    public interface IStateOptimizedEvent<T> : IDisposable
    {
        T State { get; set; }
        event Action<T> Event;
        void Invoke(T state);
    }

    public class StateOptimizedEvent<T> : Pool<StateOptimizedEvent<T>>, IStateOptimizedEvent<T>
    {
        readonly List<Action<T>> Delegates = new List<Action<T>>();

        public T State { get; set; }

        public event Action<T> Event { add { Delegates.Add(value); } remove { Delegates.Remove(value); } }

        public void Invoke(T state)
        {
            State = state;
            for (int i = Delegates.Count - 1; i >= 0; i--)
                Delegates[i](State);
        }

        protected override void OnDestroy()
        {
            Delegates.Clear();
            State = default(T);
        }
    }
    #endregion

    #region none parameters
    public interface IOptimizedEvent : IDisposable
    {
        event Action Event;
        void Invoke();
    }

    public class OptimizedEvent : Pool<OptimizedEvent>, IOptimizedEvent
    {
        readonly List<Action> Delegates = new List<Action>();

        public event Action Event
        {
            add
            {
                Delegates.Add(value);
            }

            remove
            {
                Delegates.Remove(value);
            }
        }

        public void Invoke()
        {
            for (int i = Delegates.Count - 1; i >= 0; i--)
                Delegates[i]();
        }

        protected override void OnDestroy()
        {
            Delegates.Clear();
        }
    }
    #endregion
}
