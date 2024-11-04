using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipMovement : MonoBehaviour
{
    [SerializeField] StaticCameraController camera;
    [SerializeField] Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Passage")
        {
            camera.ChangeCamera();
        //    player2.enableEntity(true);
            rb.velocity = new Vector2(0, 0);
            rb.SetRotation(0);
            //transform.position = inicialPos;
           // GetComponent<EntityController>().disableEntity(false);
        }

        if (collision.gameObject.tag == "SceneLoader")
        {
            if (PlayerContracts.instance.acceptedContract?.contractType == Contract.ContractType.position)
            {
                Debug.Log("Boss !!!!");
               // player2.SceneChanger(5);
            }
            else
            {
               // player2.SceneChanger(3);
            }


        }
    }
}
