using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticCameraController : MonoBehaviour
{
    public Transform target;

    public Vector3 offset;

    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        
        if (target == null) return;
        transform.position = new Vector3(target.position.x, target.position.y, transform.position.z) + offset;
        
    }
    public void ChangeCamera()
    {
        
    }
}
