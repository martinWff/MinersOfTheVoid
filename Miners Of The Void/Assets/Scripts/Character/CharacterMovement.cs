using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public CharacterStat movementSpeed = new CharacterStat(8);
    public Rigidbody2D rb;
    private float verticalInput, horizontalInput;
    private Camera main;
    private StaticCameraController camera;
    private Vector3 inicialPos;
    public bool animated = false;
    public bool thereIsNoHumansInSpace = false;
    public EntityController player2;
    public Animator animator;


    // Start is called before the first frame update
    void Awake()
    {
        main = Camera.main;
        camera = main.GetComponent<StaticCameraController>();
        rb = GetComponent<Rigidbody2D>();
    }  

    private void Start()
    {
        if (gameObject.tag == "Spaceship") 
        { 
            animator = gameObject.GetComponent<Animator>();
        }
        inicialPos = transform.position;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!animated)
        {
            verticalInput = Input.GetAxis("Vertical");
            if (gameObject.tag == "Player")
                horizontalInput = Input.GetAxis("Horizontal");



            Vector2 mouseDirection = Input.mousePosition - main.WorldToScreenPoint(transform.position);

            float angle = Mathf.Atan2(mouseDirection.normalized.y,
                                      mouseDirection.normalized.x) * Mathf.Rad2Deg;
            rb.SetRotation(angle);
            if (gameObject.tag == "Spaceship")
            {
                if (verticalInput != 0)
                {
                    animator.SetInteger("Moving", 1);
                }
                else
                {
                    animator.SetInteger("Moving", 0);
                }
            }
        }
     //   if (Input.GetKeyDown(KeyCode.L)) Maths.TransformUp(gameObject);
       
    }

    private void FixedUpdate()
    {
        if (!animated)
        {
            Vector2 mouseDirection = Input.mousePosition -
                Camera.main.WorldToScreenPoint(transform.position);
            if (mouseDirection.magnitude > 40)
            {
                float angle = Mathf.Atan2(mouseDirection.normalized.y,
                                      mouseDirection.normalized.x) * Mathf.Rad2Deg;
                rb.SetRotation(angle);
            }
            rb.velocity = (verticalInput * transform.right) * movementSpeed.value;
          /*  if (gameObject.tag == "Spaceship") rb.velocity = (verticalInput * transform.right) * movementSpeed.value;
            else rb.velocity = (verticalInput * Vector2.up * movementSpeed.value) + (horizontalInput * Vector2.right * movementSpeed.value);*/
        }
        else
        {
            rb.SetRotation(180);
            animator.SetInteger("Moving", 1);
            rb.velocity = (transform.right) * movementSpeed.value;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {         
            if (gameObject.tag == "Player")
            {
                if (collision.gameObject.tag == "Passage") {
                    camera.Human = false;
                    camera.ChangeCamera();
                    player2.enableEntity(false);
                    rb.velocity = new Vector2(0, 0);
                    player2.animationRun(true);
                    GetComponent<EntityController>().disableEntity(true);
                }
            }
            if (gameObject.tag == "Spaceship")
            {
                if (collision.gameObject.tag == "Passage")
                {
                    camera.ChangeCamera();
                    player2.enableEntity(true);
                    rb.velocity = new Vector2(0, 0);
                    rb.SetRotation(0);
                    //transform.position = inicialPos;
                    GetComponent<EntityController>().disableEntity(false);
                }

                if (collision.gameObject.tag == "SceneLoader")
                {
                    if(PlayerContracts.instance.acceptedContract?.contractType == Contract.ContractType.position)
                    {
                        Debug.Log("Boss !!!!");
                        player2.SceneChanger(5);
                    }
                    else
                    {
                        player2.SceneChanger(3);
                    }
                            

                }

            }
            
            
        
    }
}
