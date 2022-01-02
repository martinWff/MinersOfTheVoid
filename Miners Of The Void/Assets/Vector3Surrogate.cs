using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization;

[System.Serializable ]
public struct Vector2Serializable
{
    public float x;
    public float y;

    public static implicit operator Vector2(Vector2Serializable v2s)
    {
        return new Vector2(v2s.x, v2s.y);
    }
    public static implicit operator Vector2Serializable(Vector2 vec)
    {
        return new Vector2Serializable(vec.x, vec.y);
    }

    public static implicit operator Vector2Serializable(Vector3 vec)
    {
        return new Vector2Serializable(vec.x, vec.y);
    }

    public Vector2Serializable(float x, float y)
    {
        this.x = x;
        this.y = y;
    }

}
