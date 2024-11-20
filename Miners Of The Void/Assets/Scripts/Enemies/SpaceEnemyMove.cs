using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceEnemyMove : MonoBehaviour
{
    [SerializeField] EnemyData data;
    [SerializeField] Rigidbody2D rb;
    public float enemyRange = 15;
    public float speed = 3;
    private Vector3 targetPosition;

    public float nearPlayer = 15;
    [SerializeField] bool human;

    private Transform target => data.target;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null) return;
        Vector3 direction = target.position - transform.position;
        targetPosition = target.position;
        if (!human)
        {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rb.rotation = angle - 90;
        }


        float distance = Mathf.Sqrt(Mathf.Pow(target.position.x - transform.position.x, 2) + Mathf.Pow(target.position.y - transform.position.y, 2));
        if (distance < enemyRange)
        {
            // transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            rb.velocity = (targetPosition - transform.position).normalized * speed;
            

        }
    }
}
