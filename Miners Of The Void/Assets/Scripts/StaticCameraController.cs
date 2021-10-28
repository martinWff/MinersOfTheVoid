using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticCameraController : MonoBehaviour
{
    
    private Transform player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (player == null) return;
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
    }
}
