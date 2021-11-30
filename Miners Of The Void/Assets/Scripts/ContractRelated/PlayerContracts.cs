using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerContracts : MonoBehaviour
{
    public static PlayerContracts instance;
    public Contract acceptedContract;


    public Transform canvas;
    public GameObject contractPanelPrefab;
    public GameObject goalPanelPrefab;

    private GameObject acceptedPanel;

    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(canvas);
        instance = this;
        ContractManager.onContractAccepted += AddContract;
        ContractManager.onContractCancelled += OnCancelledContract;
        ContractManager.onContractFinished += OnFinishedContract;

    }

    public void AddContract(Contract c)
    {
        Debug.Log("ADDED CONTRACT " + c);
        acceptedContract = c;
        acceptedPanel = Instantiate(contractPanelPrefab, canvas);
        Transform insertPanel = acceptedPanel.transform.Find("Content");
        Transform buttonTransform = acceptedPanel.transform.Find("CancelButton");
        Button button = buttonTransform.GetComponent<Button>();
        button.onClick.AddListener(CancelContract);
        foreach (Goal g in c.goals)
        {
            GameObject goalObject = Instantiate(goalPanelPrefab, insertPanel);
            ContractUIController goalController = goalObject.GetComponent<ContractUIController>();
            goalController.SetGoal(g);

        }

    }

    public void CancelContract()
    {
        Debug.Log("trying to cancel contract");
        ContractManager.CancelContract(acceptedContract);
    }

    public void OnCancelledContract(Contract c)
    {
        ProcessContractEnd();
    }
    public void OnFinishedContract(Contract c)
    {
        ProcessContractEnd();

    }
    private void ProcessContractEnd()
    {
        acceptedContract.Dispose();
        acceptedContract = null;
        Destroy(acceptedPanel);
    }

}
