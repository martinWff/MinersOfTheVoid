using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class BillboardController : MonoBehaviour
{
    public GameObject canvas;
    public Health health;

    GameObject currentCanvas;


    private void Start()
    {
        currentCanvas = Instantiate(canvas);

        PositionConstraint posConstraint = currentCanvas.GetComponent<PositionConstraint>();

        ConstraintSource src = new ConstraintSource();
        src.sourceTransform = transform;
        src.weight = 1;
        posConstraint.AddSource(src);

        HealthUIController healthUI = currentCanvas.GetComponent<HealthUIController>();
        healthUI.health = health;
    }

    private void OnDestroy()
    {
        if (currentCanvas != null)
        {
            Destroy(currentCanvas);
        }
    }

    private void OnDisable()
    {
        if (currentCanvas != null)
        {
            currentCanvas.SetActive(false);
        }
    }

    private void OnEnable()
    {
        if (currentCanvas != null)
        {
            currentCanvas.SetActive(true);
        }
    }
}
