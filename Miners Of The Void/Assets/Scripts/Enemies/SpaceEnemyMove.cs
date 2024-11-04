using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceEnemyMove : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] Rigidbody2D rb;
    public float enemyRange = 15;
    public float speed = 3;
    private Vector3 targetPosition;

    public float nearPlayer = 15;
    [SerializeField] bool human;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null) return;
        Vector3 playerPosition = new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z);
        Vector3 direction = target.transform.position - transform.position;
        targetPosition = playerPosition;
        if (!human)
        {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rb.rotation = angle - 90;
        }

        
        float distance = Mathf.Sqrt(Mathf.Pow(target.transform.position.x - transform.position.x, 2) + Mathf.Pow(target.transform.position.y - transform.position.y, 2));
        if (distance < enemyRange)
        {
            // transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            rb.velocity = (targetPosition - transform.position).normalized * speed;

            if (distance > nearPlayer)
            {
                //Debug.Log("speed: " + transform.position);
               //transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

            }
            

        }
    }
}
