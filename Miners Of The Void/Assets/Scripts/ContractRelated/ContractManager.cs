using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContractManager : MonoBehaviour
{
    public Transform canvas;
    public GameObject contractPanelPrefab;
    public GameObject goalPanelPrefab;

    private static ContractManager instance;

    public delegate void ContractAccepted(Contract contract);
    public static event ContractAccepted onContractAccepted;

    public delegate void ContractFinished(Contract contract);
    public static event ContractFinished onContractFinished;


    public delegate void ContractCancelled(Contract contract);
    public static event ContractCancelled onContractCancelled;

    public static int contractsLeftUntilBoss;


    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

 
    private void _AcceptContract(Contract c)
    {
        onContractAccepted?.Invoke(c);
    }

    private void _CancelContract(Contract c)
    {
        onContractCancelled?.Invoke(c);
    }

    public static void CancelContract(Contract c)
    {
        instance._CancelContract(c);
    }

    public static void AcceptContract(Contract c)
    {
        instance._AcceptContract(c);
    }


    public static void CompleteContract(Contract c)
    {
        c.CheckGoals();
        if (c.isCompleted)
        {
            onContractFinished?.Invoke(c);
            if (contractsLeftUntilBoss > 0)
            {
                contractsLeftUntilBoss--;
            }
        }
    }
}
