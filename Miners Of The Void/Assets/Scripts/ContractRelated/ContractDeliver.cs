using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContractDeliver : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerContracts.instance.acceptedContract != null)
        {
            ContractManager.CompleteContract(PlayerContracts.instance.acceptedContract);
        }
    }
}
