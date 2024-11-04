using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class safeArea : MonoBehaviour
{
    public float safeAreaLifeTime = 9;
    public GameObject player;
    private Health immortality;
    void Start()
    {
        Destroy(gameObject, safeAreaLifeTime);
        player = GameObject.FindGameObjectWithTag("Spaceship");
        immortality = player.GetComponent<Health>();
    }

    private void Update()
    {
        if(Maths.Distance(transform.position, player.transform.position) < 5)
        {
            immortality.immortality = true;
        }
        else
        {
            immortality.immortality = false;
        }
        

    }

}
