using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Array<T>
{
    private T[] data;
    private int count;

    public int Length {
        get {
            return data.Length;
        }
    }
    public int Count
    {
        get
        {
            return count;
        }

    }

    public Array(int length) {
        data = new T[length];
        count = 0;
    }

    public T Get(int index)
    {
        if (index < 0 && index > data.Length) return default;
        return data[index];
    }

    public bool InsertAtEnd(T value)
    {
        if (count < data.Length)
        {
            data[count] = value;
            count++;
            return true;
        }
        return false;
    }
    public bool InsertAt(T value, int index)
    {
        if ((index < 0) || (index >= Length)) return false;
        else if (index == count) {
            data[count] = value;
            count++;
            return true;
        } else {

            count++;

            for (int i = count; i >= index; i--) {
                 data[i + 1] = data[i];
            }
            data[index] = value;
            return true;
        }
    }

    public bool RemoveAt(int index)
    {
        if ((index < 0) || (index > count)) return false;
        else
        {

            for (int i = index; i < count; i++)
            {
                if (i + 1 < Length) { 
                data[i] = data[i + 1];
                } 
                


            }
            count--;
            return true;
        }

    }


    public IEnumerator<T> GetEnumerator()
    {
        for ( int i = 0;i<count;i++)
        {
            yield return data[i];
        }
    }

    public bool TrueForAll(System.Predicate<T> predicate)
    {
        bool isTrue = true;
        for (int i = 0; i < count; i++)
        {
            if (isTrue)
            {
                isTrue = predicate.Invoke(data[i]);
            } else
            {
                return false;
            }
         
        }

        return isTrue;
    }

    public bool Contains(T value)
    {
        foreach (T v in data)
        {
            if (v.Equals(value))
            {
                return true;
            }
        }

        return false;
    }

    public int Find(T value)
    {
        for (int i = 0;i<Length;i++)
        {
            if (data[i].Equals(value))
            {
                return i;
            }
        }

        return -1;
    }

    public int Find(System.Predicate<T> predicate)
    {
        for (int i = 0; i < Count; i++)
        {
            if (data[i] != null)
            {
                if (predicate.Invoke(data[i]))
                {
                    return i;
                }
            }
        }

        return -1;
    }

    public bool Exists(System.Predicate<T> predicate)
    {
        for (int i = 0; i < Count; i++)
        {
            if (data[i] != null)
            {
                if (predicate.Invoke(data[i]))
                {
                    return true;
                }
            }
        }

        return false;
    }

    public static explicit operator T[](Array<T> arr)
    {
        return arr.data;
    }

    public static explicit operator Array<T>(T[] arr)
    {
        Array<T> newArray = new Array<T>(arr.Length);
        for (int i = 0; i < arr.Length; i++) {
            newArray.InsertAt(arr[i],i);
        }
        return newArray;
    }


}
