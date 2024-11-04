using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscars : MonoBehaviour
{
    [SerializeField] PersistentData persistentData;
    private void Awake()
    {
        ContractManager.onContractFinished += GetAwards;
    }
    private void GetAwards(Contract contract)
    {
        persistentData.bips += contract.bips;
        persistentData.xp += contract.famePoints;
    }

    private void OnDestroy()
    {
        ContractManager.onContractFinished -= GetAwards;
    }
}
