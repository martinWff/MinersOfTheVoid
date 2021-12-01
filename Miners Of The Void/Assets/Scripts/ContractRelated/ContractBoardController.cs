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
    // Start is called before the first frame update
    void Awake()
    {
        ContractCreator.onContractGenerated += ContractCreator_onContractGenerated;
    }

    private void ContractCreator_onContractGenerated(Contract contract)
    {
        //      GameObject copy = Instantiate(contractUI, transform);
        uniqueContract = contract;
        for (int i = 0; i < contract.goals.Count; i++) {
            GameObject goalObj = Instantiate(goalUI, contractUI.transform);
            goalObj.GetComponent<GoalControllerBoard>().SetGoal(contract.goals.Get(i));
         }
        accept.onClick.AddListener(ButtonPressed);

    }

    public void ButtonPressed()
    {
        if (PlayerContracts.instance.acceptedContract != uniqueContract)
        {
           ContractManager.AcceptContract(uniqueContract);
        }
    }

    public void Close()
    {
        contractNPC.disabled = false;
        gameObject.SetActive(false);
        
    }

  
}
