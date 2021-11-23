using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shieldbar : MonoBehaviour
{

    public Transform bar2;

    // Start is called before the first frame update
    private void Awake()
    {
        //bar2 = GameObject.Find("Bar2").GetComponent<Transform>();
        //bar2.localScale = new Vector3(0.5f, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Setsize2(float sizeNormalized)
    {

        bar2.localScale = new Vector3(sizeNormalized, 1);

    }
}
