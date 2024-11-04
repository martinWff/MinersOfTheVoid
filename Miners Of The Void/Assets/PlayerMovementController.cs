using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    private float verticalInput;

    private IMoveable moveable;

    [SerializeField] Transform targetObject;

    public bool disableMovement;

    // Start is called before the first frame update
    void Start()
    {
        moveable = targetObject.GetComponent<IMoveable>();
    }

    // Update is called once per frame
    void Update()
    {
        verticalInput = Input.GetAxis("Vertical");        

    }

    private void FixedUpdate()
    {
        if (moveable != null && !disableMovement)
        {

            Vector2 mouseDirection = Input.mousePosition -
                Camera.main.WorldToScreenPoint(targetObject.position);
            if (mouseDirection.magnitude > 40)
            {
                float angle = Mathf.Atan2(mouseDirection.normalized.y,
                                      mouseDirection.normalized.x) * Mathf.Rad2Deg;
                moveable.Look(angle);
            }


            moveable.Move(verticalInput * targetObject.right);
        }
    }
}


public interface IMoveable
{
    void Look(float angle);
    void Move(Vector2 dir);
}