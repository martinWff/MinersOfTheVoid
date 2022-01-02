using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class safeArea : MonoBehaviour
{
    public float safeAreaLifeTime = 9;
    void Start()
    {
        Destroy(gameObject, safeAreaLifeTime);
    }

}
