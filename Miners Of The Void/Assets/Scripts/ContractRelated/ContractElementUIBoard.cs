using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContractElementUIBoard : MonoBehaviour
{
    public List<GameObject> goalsUIList = new List<GameObject>();
    public Contract contract;
    public GameObject board;
    public Button button;

    public Transform requirements;
    public Transform prizes;

    public Text prizeBipsText;
    public Text prizeXPText;
    //   public List<System.Tuple<Text, Text, Image>> goalsData = new List<System.Tuple<Text, Text, Image>>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void SetContractData(Contract contract)
    {
        this.contract = contract;
        for (int i = 0;i<contract.goals.Count;i++)
        {
            SetGoalData(contract.goals.Get(i), goalsUIList[i]);
        }

        if (PlayerContracts.instance.acceptedContract != contract)
        {
            button.interactable = true;
        }

        prizeBipsText.text = "+" + contract.bips + " <color=yellow>bips</color>";
        prizeXPText.text = "+" + contract.famePoints + " <color=purple>XP</color>";
    }

    private void SetGoalData(Goal goalData,GameObject target)
    {
        target.transform.Find("GoalName").GetComponent<Text>().text = goalData.description;
        target.transform.Find("GoalAmount").GetComponent<Text>().text = goalData.requiredAmount.ToString();
        target.transform.Find("Image").GetComponent<Image>().sprite = goalData.sprite;

    }


    public void ButtonPressed()
    {
        if (PlayerContracts.instance.acceptedContract == null)
        {
            ContractManager.AcceptContract(contract);
            board.SetActive(false);
        }
        
    }
}
