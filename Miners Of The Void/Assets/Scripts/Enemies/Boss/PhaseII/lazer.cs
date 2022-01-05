using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lazer : MonoBehaviour
{



    //Camera Componets
    private Camera cam;
    private float camHeigth;
    private float camWidth;
    private float camPosX;
    private float camPosY;
    private float camPosXCurent;
    private float camPosYCurent;

    private float xpos;



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

    



}
