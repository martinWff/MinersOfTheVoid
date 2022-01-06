using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscars : MonoBehaviour
{
    private void Awake()
    {
        ContractManager.onContractFinished += GetAwards;
    }
    private void GetAwards(Contract contract)
    {
        SavePlayerStats.bips += contract.bips;
        SavePlayerStats.exp += contract.famePoints;

    }

    private void OnDestroy()
    {
        ContractManager.onContractFinished -= GetAwards;
    }
}
