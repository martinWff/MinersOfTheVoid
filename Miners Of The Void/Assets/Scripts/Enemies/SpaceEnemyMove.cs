using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceEnemyMove : MonoBehaviour
{
    private GameObject spaceship;


    // Start is called before the first frame update
    void Start()
    {
        spaceship = GameObject.FindGameObjectWithTag("Sapceship");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
