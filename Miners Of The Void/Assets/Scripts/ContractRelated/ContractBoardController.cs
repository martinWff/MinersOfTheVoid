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
        //ContractCreator.onContractGenerated += ContractCreator_onContractGenerated;
        
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
            accept.onClick.AddListener(ButtonPressed);
        }

    }

    public void ButtonPressed()
    {
        if (PlayerContracts.instance.acceptedContract != uniqueContract)
        {
           ContractManager.AcceptContract(uniqueContract);
        }
        gameObject.SetActive(false);
    }

    public void Close()
    {
        
        gameObject.SetActive(false);
        
    }

    private void OnDisable()
    {
        contractNPC.disabled = false;
    }


}
