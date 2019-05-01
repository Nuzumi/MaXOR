using System;
using System.Collections.Generic;

namespace Maxor.Utils
{
    [AttributeUsage(AttributeTargets.Class, Inherited = true)]
    public class PrefabAttribute : Attribute
    {
        static Dictionary<Type, string> Cache = new Dictionary<Type, string>();
        readonly public string Value;

        static public string GetPrefabPath<T>()
        {
            return GetPrefabPath(typeof(T));
        }

        static public string GetPrefabPath(Type type)
        {
            string value = null;
            if (!Cache.TryGetValue(type, out value))
            {
                value = ((PrefabAttribute)(type.GetCustomAttributes(typeof(PrefabAttribute), true)[0])).Value;
                Cache[type] = value;
            }
            return value;
        }

        public PrefabAttribute(string value)
        {
            Value = value;
        }
    }
}
