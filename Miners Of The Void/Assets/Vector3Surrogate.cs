using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization;

[System.Serializable ]
public struct Vector3Serializable
{
    public float x;
    public float y;
    public float z;


    public static implicit operator Vector3(Vector3Serializable v2s)
    {
        return new Vector3(v2s.x, v2s.y,v2s.z);
    }

    public static implicit operator Vector3Serializable(Vector3 vec)
    {
        return new Vector3Serializable(vec.x, vec.y,vec.z);
    }

    public Vector3Serializable(float x, float y,float z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }

}
