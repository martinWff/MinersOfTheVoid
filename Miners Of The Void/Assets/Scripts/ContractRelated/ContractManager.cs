using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public static int contractsLeftUntilBoss;


    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

 
    private void _AcceptContract(Contract c)
    {
        GameObject panel = Instantiate(contractPanelPrefab,canvas);
        Transform insertPanel = panel.transform.Find("Content");
        foreach (Goal g in c.goals)
        {
            GameObject goalObject = Instantiate(goalPanelPrefab, insertPanel);
            ContractUIController goalController = goalObject.GetComponent<ContractUIController>();
            goalController.SetGoal(g);

        }
        onContractAccepted?.Invoke(c);
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
