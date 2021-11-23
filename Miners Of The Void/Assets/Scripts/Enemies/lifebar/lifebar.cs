using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lifebar : MonoBehaviour
{

    public Transform bar;
    // Start is called before the first frame update
    private void Awake()
    {

        //bar = GameObject.Find("Bar").GetComponent<Transform>();
        //bar.localScale = new Vector3(0.5f, 1);

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //sizeNormalized is a valeue between 0 and 1
    public void Setsize(float sizeNormalized)
    {
        
        bar.localScale = new Vector3(sizeNormalized, 1);
        
    }
}
