using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticCameraController : MonoBehaviour
{
    public bool Human;
    private Transform player;
    void Start()
    {   if (Human)
            player = GameObject.Find("HumanPlayer").transform;
        else
            player = GameObject.Find("PlayerSpaceship").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (player == null) return;
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
    }
}
