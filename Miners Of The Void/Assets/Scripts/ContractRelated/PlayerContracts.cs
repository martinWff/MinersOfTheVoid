using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerContracts : MonoBehaviour
{
    public static PlayerContracts instance;
    public Contract acceptedContract { get; private set; }

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

            ContractManager.onContractAccepted += OnContractAccepted;
            ContractManager.onContractCancelled += OnCancelledContract;
            ContractManager.onContractFinished += OnFinishedContract;
            SaveManager.saveStarted += OnSaveContracts;
            SaveManager.saveLoaded += OnLoadContracts;
        }

    }
    
    private void OnSaveContracts(SavedData saveData)
    {
        saveData.currentContract = acceptedContract;
        saveData.contracts = (Contract[])ContractGenerator.contracts;
    }

    private void OnLoadContracts(SavedData saveData)
    {
       
        ContractGenerator.contracts = (Array<Contract>)saveData.contracts;

        foreach (Contract c in ContractGenerator.contracts)
        {
            foreach (Goal g in c.goals)
            {
                g.OnLoaded();
            }
        }
        if (acceptedContract == null)
        {
            ContractManager.AcceptContract(saveData.currentContract);
        }


    }

    private void OnContractAccepted(Contract c)
    {
        if (acceptedContract == null && c != null)
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

            c.Start();

            c.CheckGoals();


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
        //acceptedContract.GiveRewards();
        ProcessContractEnd();

    }
    private void ProcessContractEnd()
    {
        acceptedContract.Dispose();
        acceptedContract = null;
        Destroy(acceptedPanel);
    }

}
