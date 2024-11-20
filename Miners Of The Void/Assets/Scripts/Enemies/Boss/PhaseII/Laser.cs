using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{

    public SpriteRenderer spriteRenderer;

    private bool laserIsActive;

    //Camera Componets
    private Camera cam;
    private float camHeigth;
    private float camWidth;
    private float camPosX;
    private float camPosY;
    private float camPosXCurent;
    private float camPosYCurent;

    private float xpos;

    public float damage = 5;


    void Start()
    {
        cam = Camera.main;
        camPosX = cam.transform.position.x;
        camPosY = cam.transform.position.y;
        camHeigth = 2f * cam.orthographicSize;
        camWidth = camHeigth * cam.aspect;
        camPosXCurent = camPosX - camWidth / 2;
        camPosYCurent = camPosY + camHeigth / 2;

        

        transform.localScale = new Vector3(0.5f, camHeigth/4, 0);
        //Debug.Log(camHeigth / 2);
        transform.localPosition = new Vector3(0, -3, 0);

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (laserIsActive && collision.CompareTag("Player"))
        {
            IDamageable health = collision.GetComponent<IDamageable>();
            if (health != null)
            {
                health.TakeDamage(damage);
            }
        }
    }

    public void Activate()
    {
        laserIsActive = true;
    }

    public void Deactivate()
    {
        laserIsActive = false;
    }

    public bool IsRunning()
    {
        return laserIsActive;
    }


}
