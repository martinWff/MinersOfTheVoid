using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContractCreator : MonoBehaviour
{
    public Array<Contract> contracts = new Array<Contract>(4);
    public delegate void ContractGenerated(Contract contract);
    public static event ContractGenerated onContractGenerated;


    // Start is called before the first frame update
    void Start()
    {
      /*  Array<Goal> contractGoals = new Array<Goal>(3);
       
        contractGoals.InsertAtEnd(new GatheringGoal(OreManager.instance.GetOreMaterialByMaterialName("Iron").GetOreStack(6)));
        contractGoals.InsertAtEnd(new GatheringGoal(OreManager.instance.GetOreMaterialByMaterialName("Osmium").GetOreStack(6)));
        Contract contract = new Contract(Contract.ContractType.mining, contractGoals);
        contract.bips = 250;
        contracts.InsertAt(new Contract(Contract.ContractType.mining,contractGoals),0);
        onContractGenerated?.Invoke(contract);*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
