using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PirateExplosion : MonoBehaviour
{

    private GameObject spaceship;
    private float distance;
    private Rigidbody2D enemy;
    public float enemyRange = 30;
    public float speed = 3;
    private Vector3 targetPosition;

    SpriteRenderer pirate_spriterender;
    Color pirate_NewColor;


    // Start is called before the first frame update
    void Start()
    {
        spaceship = GameObject.FindGameObjectWithTag("Spaceship");
        enemy = GetComponent<Rigidbody2D>();
        pirate_spriterender = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (spaceship == null) return;
        Vector3 playerPosition = new Vector3(spaceship.transform.position.x, spaceship.transform.position.y, spaceship.transform.position.z);
        Vector3 direction = spaceship.transform.position - transform.position;
        targetPosition = playerPosition;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        enemy.rotation = angle - 90;

        distance = Mathf.Sqrt(Mathf.Pow(spaceship.transform.position.x - transform.position.x, 2) + Mathf.Pow(spaceship.transform.position.y - transform.position.y, 2));
        if (distance < enemyRange)
        {
            


        }
    }
}
