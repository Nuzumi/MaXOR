using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maxor.Model.Tree
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

        public override string ToString()
        {
            return "+";
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

        public override string ToString()
        {
            return "x";
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

        public override string ToString()
        {
            return "-";
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

        public override string ToString()
        {
            return "/";
        }
    }

    public class Factorial : IEquation
    {
        public float GetResult(float[] values)
        {
            if (values.Length != 1)
                throw new ArgumentCountException();

            int result = 1;
            for (int i = 2; i < values[0]; i++)
                result *= i;

            return result;
        }

        public override string ToString()
        {
            return "!";
        }
    }

    public class Element : IEquation
    {
        public float GetResult(float[] values)
        {
            if (values.Length != 1)
                throw new ArgumentCountException();

            return (int)Math.Pow(values[0], .5f);
        }

        public override string ToString()
        {
            return "^1/2";
        }
    }

    public class ArgumentCountException : ArgumentException
    {

    }
}

