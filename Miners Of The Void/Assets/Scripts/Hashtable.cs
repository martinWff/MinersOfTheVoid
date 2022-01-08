using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HashtableNode
{
    public string Key { set; get; }
    public object Value { set; get; }
    public HashtableNode Next { set; get; }

    public HashtableNode(string key, object value)
    {
        Key = key;
        Value = value;
        Next = null;
    }
}
[System.Serializable]
public class Hashtable
{
    private int i = 0;
    private HashtableNode[] buckets;
    private int tableSize;

    public Hashtable(int size)
    {
        buckets = new HashtableNode[size];
        tableSize = size;
    }

    private int HashFunction(string key)
    {
        long index = 7;
        int asciiCode = 0;
        for (int i = 0; i < key.Length; i++)
        {
            asciiCode = (int)key[i] * i;
            index = index * 31 + asciiCode;
        }
        return (int)(index % tableSize);
    }
    public void Insert(string key, object value)
    {
        i++;
        int hashIndex = HashFunction(key);
        HashtableNode node = buckets[hashIndex];
        if (node == null)
        {
            buckets[hashIndex] = new HashtableNode(key, value);
        }
        else
        {
            if (node.Key == key)
            {
                node.Value = value;
            }
            else
            {
                while (node.Next != null)
                {
                    
                    node = node.Next;
                    if (node.Key == key)
                    {
                        node.Value = value;
                        break;
                    }
                }
                HashtableNode newNode = new HashtableNode(key, value);
                node.Next = newNode;
            }
            
        }
    }
    public object GetValue(string key)
    {
        int hashIndex = HashFunction(key);
        HashtableNode node = buckets[hashIndex];
        while (node != null)
        {
            if (node.Key == key)
            {
                return node.Value;
            }
            node = node.Next;
        }
        return null;
    }

    public bool Remove(string key)
    {
        int hashIndex = HashFunction(key);
        HashtableNode node = buckets[hashIndex];
        if (node == null) return false;
        if(node.Key == key)
        {
            buckets[hashIndex] = node.Next;
            i--;
            return true;
            
        }
        HashtableNode previous = node;
        while(node != null)
        {
            if(node.Key == key)
            {
                previous.Next = node.Next;
                i--;
                return true;
            }
                previous = node;
                node = node.Next;
        }
        return false;
    }
    public bool ContainsKey(string key)
    {
        int hashIndex = HashFunction(key);
        HashtableNode node = buckets[hashIndex];
        while (node != null)
        {
            if (node.Key == key)
            {
                return true;
            }
            node = node.Next;
        }
        return false;
    }
    public bool ContainsValue(object value)
    {
        foreach (HashtableNode node in buckets)
        {
            if (node != null)
            {
                if (node.Value == value)
                {
                    return true;
                }
                HashtableNode nextNode = node.Next;
                if (nextNode != null)
                {
                    while (nextNode != null)
                    {
                        if (nextNode.Value == value)
                        {
                            return true;
                        }
                        else nextNode = node.Next;
                    }
                    return false;
                }
            }   
        }
        return false;
    }
    public int Count()
    { 
        return i;
        
    }
       
}
