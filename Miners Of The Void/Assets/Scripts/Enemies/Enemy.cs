using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public Transform target => enemyData.target;
    private float targetDistance;

    public System.Action<GameObject> boss;
    public EnemyData enemyData;

    //Enemy shoot
    public GameObject bulletPrefab;
    public float bulletOffset = 4f;
    public float bulletSpeed = 14;
    public float bulletCooldownTime = 0.5f;
    private float bulletShootTime = 0.5f;
    public float enemyRange = 20;

    public AudioSource audioSource;



    //Enemy rotation
    [SerializeField]private Rigidbody2D rb;



    void Start()
    {
       
    }


    void Update()
    {
        

        if (target == null) return;
        Vector3 direction = target.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle - 90;


        targetDistance = Mathf.Sqrt(Mathf.Pow(target.transform.position.x - transform.position.x, 2) + Mathf.Pow(target.transform.position.y - transform.position.y, 2));
        if (targetDistance < enemyRange)
        {
            if (bulletShootTime <= 0)
            {


                //Debug.Log(bulletPrefab);
                Vector3 shotDirection = Maths.TransformUp(gameObject);

                //GameObject bullet = EnemyPool.bulletInstanse.GetEnemyBullet();
                //bullet.SetActive(true);
                //bullet.transform.position = transform.position + (Shotdirection.normalized * bulletOffset);
                //Debug.Log("posição da bala "+bullet.transform.position);
                GameObject bullet = Instantiate(bulletPrefab, transform.position + (shotDirection.normalized * bulletOffset), Quaternion.identity);
                bulletShootTime = bulletCooldownTime;
                bullet.GetComponent<Rigidbody2D>().velocity = shotDirection.normalized * bulletSpeed;
                if (audioSource != null && audioSource.clip != null)
                {
                    Debug.Log("play clip");
                    audioSource.Play();
                }
            }
            if (bulletShootTime >= 0)
            {
                bulletShootTime -= Time.deltaTime;
            }
        }


        
    }



}