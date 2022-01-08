using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ContractFeedBackBehaviour : MonoBehaviour
{
    private static ContractFeedBackBehaviour instance;
    public GameObject panel;
    public Text statusText;
    public Text rewardText;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            ContractManager.onContractAccepted += OnContractAccepted;
            ContractManager.onContractFinished += OnContractFinished;
            instance = this;
        }
    }

    
    public void OnContractAccepted(Contract contract)
    {
        Show("New contract accepted");
    }
    public void OnContractFinished(Contract contract)
    {
        string contractReward = $"Reward: <color=red> +{contract.bips} Bips </color>  <color=purple>+{contract.famePoints} XP </color>";

        if (contract.contractType == Contract.ContractType.position)
        {
            contractReward = contractReward + " World Level Increased "+ (SavePlayerStats.level + 1).ToString();
        }
        ShowWithReward("You sucessfully finished the contract", contractReward);


    }

    public void Show(string text)
    {
        panel.SetActive(true);
        statusText.text = text;
        StartCoroutine(HideAfter(3));

    }

    public void ShowWithReward(string text,string reward)
    {
        rewardText.gameObject.SetActive(true);
        rewardText.text = reward;
        Debug.Log(reward);
        Show(text);
        

    }

    public IEnumerator HideAfter(int seconds)
    {
        yield return new WaitForSeconds(seconds);

        panel.SetActive(false);
        if (rewardText.gameObject.activeSelf)
        {
            rewardText.gameObject.SetActive(false);
        }
    }
}
