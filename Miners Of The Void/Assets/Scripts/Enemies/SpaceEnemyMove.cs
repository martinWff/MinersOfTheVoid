using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceEnemyMove : MonoBehaviour
{
    private GameObject spaceship;
    private float distance;
    private Rigidbody2D enemy;
    public float enemyRange = 30;
    public float speed = 3;
    private Vector3 targetPosition;
    public bool human = true; 

    public float nearPlayer = 15;

    // Start is called before the first frame update
    void Start()
    {

        if(human)spaceship = GameObject.FindGameObjectWithTag("Player"); else spaceship = GameObject.FindGameObjectWithTag("Spaceship");
        Debug.Log(spaceship);
        enemy = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (spaceship == null) return;
        Vector3 playerPosition = new Vector3(spaceship.transform.position.x, spaceship.transform.position.y, spaceship.transform.position.z);
        Vector3 direction = spaceship.transform.position - transform.position;
        targetPosition = playerPosition;
        if (!human)
        {
            //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            //enemy.rotation = angle - 90;
        }
        

        distance = Mathf.Sqrt(Mathf.Pow(spaceship.transform.position.x - transform.position.x, 2) + Mathf.Pow(spaceship.transform.position.y - transform.position.y, 2));
        if (distance < enemyRange)
        {
            if(distance > nearPlayer)
            {
                //Debug.Log("speed: " + transform.position);
               transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

            }
            

        }
    }
}
