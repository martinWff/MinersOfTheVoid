using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletLifeTime = 5;
    


    void Start()
    {
        
        Destroy(gameObject, bulletLifeTime);
    }

    private void Update()
    {
       
    }



    
    
}
