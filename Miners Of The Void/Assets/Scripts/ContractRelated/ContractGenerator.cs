using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContractGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateContract()
    {
        if (ContractManager.contractsLeftUntilBoss < 0)
        {

        } 
    }

    public Contract GenerateContract()
    {


        if (ContractManager.contractsLeftUntilBoss < 0)
        {
            return GenerateBossContract();
        }

        return null;
       
    }

    public Contract GenerateBossContract()
    {
        Array<Goal> arr = new Array<Goal>(1);
        arr.InsertAtEnd(new KillGoal("boss", "Kill the Boss", 1));

        Contract c = new Contract(Contract.ContractType.position, arr);

        return c;

    }

    private void PickGatherGoal()
    {
       // GatheringGoal g = new GatheringGoal("iron", "mine 3 gold", Random.Range(0, 5));
    }

}
