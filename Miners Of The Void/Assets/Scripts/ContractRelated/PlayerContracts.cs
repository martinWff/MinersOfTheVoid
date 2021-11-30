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

        if (instance == null)
        {
            instance = this;
            if (canvas != null)
            {
                DontDestroyOnLoad(canvas);
            }

            ContractManager.onContractAccepted += AddContract;
            ContractManager.onContractCancelled += OnCancelledContract;
            ContractManager.onContractFinished += OnFinishedContract;
        }

    }

    public void AddContract(Contract c)
    {
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
        ContractManager.CancelContract(acceptedContract);
    }

    public void OnCancelledContract(Contract c)
    {
        ProcessContractEnd();
    }
    public void OnFinishedContract(Contract c)
    {
        acceptedContract.GiveRewards();
        ProcessContractEnd();

    }
    private void ProcessContractEnd()
    {
        acceptedContract.Dispose();
        acceptedContract = null;
        Destroy(acceptedPanel);
    }

}
