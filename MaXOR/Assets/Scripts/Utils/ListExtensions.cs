using System;
using System.Collections.Generic;

public static class List
{
    public static Random rng = new Random();

    public static List<T> Of<T>(params T[] elements)
    {
        return new List<T>(elements);
    }

    public static bool AreEquals<T>(List<T> left, List<T> right)
    {
        if (left.Count != right.Count)
            return false;
        else if (left != null ^ right != null)
            return false;
        else if (left != null)
            for (var i = 0; i < left.Count; i++)
                if (!left[i].Equals(right[i]))
                    return false;
        return true;
    }

    public static void Shuffle<T>(this IList<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }

    public static List<T> FillUp<T>(List<T> collection, T value, int targetCount)
    {
        if (collection.Count >= targetCount)
            return collection;
        collection.Capacity = targetCount;
        for (int i = collection.Count; i < targetCount; ++i)
            collection.Add(value);
        return collection;
    }

    public static T RandomElement<T>(this List<T> list)
    {
        return list[rng.Next(list.Count)];
    }

    public static bool NotContains<T>(this List<T> list, T element)
    {
        return !list.Contains(element);
    }

    public static void AddIfNotPresent<T>(this List<T> list, T element)
    {
        if (list.NotContains(element))
            list.Add(element);
    }

    public static T Last<T>(this List<T> list)
    {
        if (list.Count > 0)
            return list[list.Count - 1];
        return default(T);
    }

    public static List<T> RemoveDuplicates<T>(this List<T> list)
    {
        for (var i = list.Count - 1; i > 0; i--)
            if (list.IndexOf(list[i]) != i)
                list.RemoveAt(i);
        return list;
    }

    public static string Join<T>(this List<T> list, string separator)
    {
        return string.Join(separator, list.ConvertAll(o => o.ToString()).ToArray());
    }

    public static List<T> Copy<T>(this List<T> list)
    {
        return new List<T>(list);
    }

    public static float Sum<T>(this List<T> list, Converter<T, float> converter)
    {
        var sum = 0f;
        list.ConvertAll(converter).ForEach(element => sum += element);
        return sum;
    }

    public static float Sum(this List<float> list)
    {
        var sum = 0f;
        list.ForEach(element => sum += element);
        return sum;
    }

    public static int Sum(this List<int> list)
    {
        var sum = 0;
        list.ForEach(element => sum += element);
        return sum;
    }

    public static List<T> Shuffle<T>(this List<T> toShuffle, long key)
    {
        int size = toShuffle.Count;
        T[] list = toShuffle.ToArray();

        Random random = new Random(Convert.ToInt32(key));
        for (int i = 0; i < size; i++)
        {
            int n = random.Next(size);
            T tmp = list[i];
            list[i] = list[n];
            list[n] = tmp;
        }
        return new List<T>(list);
    }

    public static List<T> ShuffleFY<T>(this List<T> toShuffle, int key)
    {
        int size = toShuffle.Count;
        T[] array = toShuffle.ToArray();

        Random random = new Random(key);
        for (int i = 0; i < size; i++)
        {
            int rand = i + (int)(random.NextDouble() * (size - i));
            T temp = array[i];
            array[i] = array[rand];
            array[rand] = temp;
        }
        return new List<T>(array);
    }

    public static int ClosestIndex(this IList<double> list, double value)
    {
        int index = -1;
        double minDiff = double.MaxValue;
        for (int i = 0; i < list.Count; i++)
        {
            double diff = Math.Abs(list[i] - value);
            if (minDiff > diff)
            {
                minDiff = diff;
                index = i;
            }
        }

        return index;
    }

    public static int ClosestIndex(this IList<int> list, int value)
    {
        int index = -1;
        int minDiff = int.MaxValue;
        for (int i = 0; i < list.Count; i++)
        {
            int diff = Math.Abs(list[i] - value);
            if (minDiff > diff)
            {
                minDiff = diff;
                index = i;
            }
        }

        return index;
    }

    public static int NextGreaterIndex(this IList<int> list, int value)
    {
        int index = -1;
        int nextGreaterValue = int.MaxValue;

        for (int i = 0; i < list.Count; i++)
        {
            if (list[i] > value && list[i] < nextGreaterValue)
            {
                nextGreaterValue = list[i];
                index = i;
            }
        }
        return index;
    }
}