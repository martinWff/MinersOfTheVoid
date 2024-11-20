using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockWave : MonoBehaviour
{

    public float bulletLifeTime = 3;
    public float damage = 3;

    //cam
    private Camera cam;
    private float camHeigth;
    private float camWidth;


    void Start()
    {

        cam = Camera.main;
        camHeigth = 2f * cam.orthographicSize;
        camWidth = camHeigth * cam.aspect;

        transform.localScale = new Vector3(camWidth, 0.5f, 0);

        Destroy(gameObject, bulletLifeTime);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            IDamageable health = collision.GetComponent<IDamageable>();
            if (health != null)
            {
                health.TakeDamage(damage);
            }
        }
    }

}
