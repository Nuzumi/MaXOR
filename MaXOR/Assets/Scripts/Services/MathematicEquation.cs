using System;
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

    public class Subtraction : IEquation
    {
        public float GetResult(float[] values)
        {
            if (values.Length != 2)
                throw new ArgumentCountException();

            return values[0] - values[1];
        }
    }

    public class Division : IEquation
    {
        public float GetResult(float[] values)
        {
            if (values.Length != 2)
                throw new ArgumentCountException();

            return values[0] / values[1];
        }
    }

    public class ArgumentCountException : ArgumentException
    {

    }
}

