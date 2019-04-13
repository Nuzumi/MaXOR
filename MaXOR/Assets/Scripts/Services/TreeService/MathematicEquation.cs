using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MaXOR.Services.Tree
{
    public interface IEquation
    {
        float GetResult(float[] values);
    }

    public class Sum : IEquation
    {
        public float GetResult(float[] values)
        {
            float result = 0;
            for (int i = 0; i < values.Length; i++)
                result += values[i];
            return result;
        }
    }

    public class Multiplication : IEquation
    {
        public float GetResult(float[] values)
        {
            float result = 1;
            for (int i = 0; i < values.Length; i++)
                result *= values[i];
            return result;
        }
    }
}

