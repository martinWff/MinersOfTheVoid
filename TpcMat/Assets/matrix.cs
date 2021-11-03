using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class matrix : MonoBehaviour
    
{
    public Matrix4x4 trans;
    // Start is called before the first frame update
    
    // Update is called once per frame
    void FixedUpdate()
    {
        trans = transform.worldToLocalMatrix;
    }
}
