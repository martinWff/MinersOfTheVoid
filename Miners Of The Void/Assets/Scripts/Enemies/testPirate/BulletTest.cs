using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTest : MonoBehaviour
{
    public Vector2 moveDirection;
    private float moveSpeed = 5f;

    //player colision
  
    GameObject player;
    SpaceshipMovement sM;

    private void OnEnable()
    {
        Invoke("Destroy", 4f);
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("PlayerSpaceship");
        sM = player.GetComponent<SpaceshipMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }

    public void SetMoveDirection(Vector2 dir)
    {
        moveDirection = dir;
    }

    private void Destroy()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }
    
    
private void OnTriggerEnter2D(Collider2D collision)
{
        if (collision.gameObject.tag == "Spaceship")
        {
            Destroy(gameObject);
            
        }

    }
}
