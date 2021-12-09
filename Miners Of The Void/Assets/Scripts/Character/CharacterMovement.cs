using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public CharacterStat movementSpeed = new CharacterStat(4);
    public Rigidbody2D rb;
    private float verticalInput, horizontalInput;
    private Camera main;
    // Start is called before the first frame update
    void Awake()
    {
        main = Camera.main;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");


        Vector2 mouseDirection = Input.mousePosition - main.WorldToScreenPoint(transform.position);

        float angle = Mathf.Atan2(mouseDirection.normalized.y,
                                  mouseDirection.normalized.x) * Mathf.Rad2Deg;
        rb.SetRotation(angle);
    }

    private void FixedUpdate()
    {
        rb.velocity = (verticalInput * Vector2.up * movementSpeed.value) + (horizontalInput * Vector2.right * movementSpeed.value);
    }
}
