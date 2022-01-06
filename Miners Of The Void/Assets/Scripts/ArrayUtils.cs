using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ArrayUtils
{
    public static int Find<T>(T[] array, System.Predicate<T> predicate)
    {
        if (array == null) return -1;
        for (int i = 0; i < array.Length; i++) {
            if (predicate.Invoke(array[i]))
            {
                return i;
            }
        }

        return -1;

    }

    public static bool Exist<T>(T[] array, System.Predicate<T> predicate)
    {
        for (int i = 0; i < array.Length; i++)
        {
            if (predicate.Invoke(array[i]))
            {
                return true;
            }
        }

        return false;

    }
}
