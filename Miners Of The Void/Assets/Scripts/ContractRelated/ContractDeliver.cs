using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContractDeliver : MonoBehaviour
{
    // Start is called before the first frame update

    private void Awake()
    {
        ContractManager.onContractAccepted += TestContract;
    }

    private void OnDestroy()
    {
        ContractManager.onContractAccepted -= TestContract;
    }

    void Start()
    {
        if (PlayerContracts.instance.acceptedContract != null)
        {
            ContractManager.CompleteContract(PlayerContracts.instance.acceptedContract);
        }
    }


    void TestContract(Contract c)
    {
        StartCoroutine(LateTestContract(2,c));
    }


    IEnumerator LateTestContract(float delay, Contract c)
    {
        yield return new WaitForSeconds(delay);
        ContractManager.CompleteContract(c);
    }
}
