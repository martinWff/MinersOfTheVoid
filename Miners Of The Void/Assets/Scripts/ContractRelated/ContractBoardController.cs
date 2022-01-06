using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContractBoardController : MonoBehaviour
{
    public ContractNPC contractNPC;
    public GameObject contractUI;
    public GameObject goalUI;
    public Contract uniqueContract;
    public Button accept;
    public GameObject contractPanelBoard;
    public Transform contractPanelList;

    private List<GameObject> contractPanels = new List<GameObject>();
    // Start is called before the first frame update
    void Awake()
    {
        //ContractCreator.onContractGenerated += ContractCreator_onContractGenerated;
       /* ContractGenerator.onContractGenerated += ContractCreator_onContractGenerated;
        foreach (Contract contract in contractGenerator.contracts)
        {
            CreateContractLabel(contract);
        }*/

    }


    private void OnEnable()
    {
        foreach (Contract contract in ContractGenerator.contracts)
        {
            CreateContractLabel(contract);
        }
    }

    public void ContractCreator_onContractGenerated(Contract contract)
    {
        //      GameObject copy = Instantiate(contractUI, transform);
        uniqueContract = contract;
        if (contractUI != null)
        {
            for (int i = 0; i < contract.goals.Count; i++)
            {
                GameObject goalObj = Instantiate(goalUI, contractUI.transform);
                goalObj.GetComponent<GoalControllerBoard>().SetGoal(contract.goals.Get(i));
            }
           
        }

    }

    private void CreateContractLabel(Contract contract)
    {
        GameObject newContractPanel = Instantiate(contractPanelBoard, contractPanelList);
        ContractElementUIBoard contractElementUI = newContractPanel.GetComponent<ContractElementUIBoard>();
        contractElementUI.board = gameObject;
        for (int i = 0; i < contract.goals.Count; i++)
        {
            GameObject goalObj = Instantiate(goalUI, contractElementUI.requirements);
       //     goalObj.GetComponent<GoalControllerBoard>().SetGoal(contract.goals.Get(i));
            contractElementUI.goalsUIList.Add(goalObj);
            


        }
        
        contractElementUI.SetContractData(contract);
        contractPanels.Add(newContractPanel);

    }


   /* public void ButtonPressed()
    {
        if (PlayerContracts.instance.acceptedContract == null)
        {
           ContractManager.AcceptContract(uniqueContract);
        }
        gameObject.SetActive(false);
    }*/

    public void Close()
    {
        
        gameObject.SetActive(false);
        
    }

    private void OnDisable()
    {
        contractNPC.disabled = false;
        for (int i = contractPanels.Count-1; i >= 0; i--) {
            Destroy(contractPanels[i]);
        }
    }


}
