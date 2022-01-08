using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ArrayUtils
{
    public static int Find<T>(T[] array, System.Predicate<T> predicate)
    {
        if (predicate !=null)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (predicate.Invoke(array[i]))
                {
                    return i;
                }
            }
        }
        return -1;

    }
    public static bool FindAndGet<T>(T[] array, System.Predicate<T> predicate,out T value)
    {
        if (predicate != null)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (predicate.Invoke(array[i]))
                {
                    value = array[i];
                    return true;
                }
            }
        }
        value = default(T);
        
        return false;

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
