using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ContractFeedBackBehaviour : MonoBehaviour
{
    public Image panel;
    public Text textObject;
    // Start is called before the first frame update
    void Awake()
    {
        ContractManager.onContractAccepted += OnContractAccepted;
        ContractManager.onContractFinished += OnContractFinished;
        panel.enabled = true;
        textObject.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnContractAccepted(Contract contract)
    {
        // textObject.text = "New contract accepted";

        Show("New contract accepted");
    }
    public void OnContractFinished(Contract contract)
    {
        //   textObject.text = "You sucessfully finished the contract";
        Show("You sucessfully finished the contract");


    }

    public void Show(string text)
    {
        gameObject.SetActive(true);
        textObject.text = text;
        StartCoroutine(HideAfter(5));

    }

    public IEnumerator HideAfter(int seconds)
    {
        yield return new WaitForSeconds(seconds);

        gameObject.SetActive(false);
    }
}
