using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PirateExplosionMove : MonoBehaviour
{
    //movement
    private PirateExploosion pirate;
    private Vector3 targetPositionChildren;
    private float speed;
    private bool attack;

    //enemy
    private Rigidbody2D enemy;


    void Start()
    {
        enemy = GetComponent<Rigidbody2D>();
        pirate = GetComponentInChildren<PirateExploosion>();
        speed = pirate.speed;
        
    }

    // Update is called once per frame
    void Update()
    {
        targetPositionChildren = pirate.targetPosition;
        attack = pirate.attack;
        //Debug.Log(attack);

        if (attack == true)
        {
            //Debug.Log("chegou aqui");
            
            transform.position = Vector3.MoveTowards(transform.position, targetPositionChildren, speed * Time.deltaTime);
            //Debug.Log(targetPositionChildren);
            //Debug.Log(transform.position);

        }
    }
}
