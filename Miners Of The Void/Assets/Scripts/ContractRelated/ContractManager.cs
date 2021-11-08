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

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

 
    private void _AcceptContract(Contract c)
    {
        GameObject panel = Instantiate(contractPanelPrefab,canvas);
        foreach (Goal g in c.goals)
        {
            GameObject goalObject = Instantiate(goalPanelPrefab, panel.transform);
            ContractUIController goalController = goalObject.GetComponent<ContractUIController>();
            goalController.SetGoal(g);

        }
        onContractAccepted?.Invoke(c);
    }

    public static void AcceptContract(Contract c)
    {
        instance._AcceptContract(c);
    }
}
