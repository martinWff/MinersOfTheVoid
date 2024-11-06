using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PirateExplosion : MonoBehaviour
{

    Transform target => enemyData.target;
    private float distance;
    [SerializeField] Rigidbody2D rb;
    public float enemyRange = 20;
    public float speed = 15;

    public EnemyData enemyData;

    [SerializeField] private SpriteRenderer alarm;

    public Vector3 targetPosition;

    //stop the alarm 
    public bool isAttacking = false;
    private bool preparingAttack = false;

    private Color alarmColor;

    public float damage;

    // Start is called before the first frame update
    void Start()
    {
        alarmColor = alarm.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null) return;


        distance = Mathf.Sqrt(Mathf.Pow(target.position.x - transform.position.x, 2) + Mathf.Pow(target.position.y - transform.position.y, 2));
        if (distance < enemyRange)
        {
            Warning();
        }
        else
        {
            alarm.color = alarmColor;
        }

        if (isAttacking && distance < 0.5f)
        {
            isAttacking = false;
        }
    }


    public void Warning()
    {

        if (!isAttacking && !preparingAttack)
        {
            Vector3 direction = target.position - transform.position;
            targetPosition = target.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rb.rotation = angle - 90;

            preparingAttack = true;

            StartCoroutine(Blinking());
        }
    }

    private IEnumerator Blinking()
    {
        Color transparent = new Color(0, 0, 0, 0);

        for (int i = 0;i<5;i++)
        {
            alarm.color = transparent;
            yield return new WaitForSeconds(0.5f);
            alarm.color = alarmColor;
            yield return new WaitForSeconds(0.5f);

        }
        isAttacking = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.collider.CompareTag(gameObject.tag))
        {
            IDamageable damageable = collision.collider.GetComponent<IDamageable>();
            if (damageable != null)
            {
                damageable.TakeDamage(damage);
            }

            Destroy(transform.parent.gameObject);
        }
    }
}