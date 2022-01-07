using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContractCanvasHandler : MonoBehaviour
{
    public static ContractCanvasHandler instance { get; private set; }
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

}
