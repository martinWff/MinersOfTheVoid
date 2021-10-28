using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContractTest : MonoBehaviour
{
    public Inventory inventory;

    public Contract oreContract;

   // public Contract<EnemyKill> enemyContract;
    // Start is called before the first frame update
    void Start()
    {
        inventory = new Inventory();
        Array<Goal> oreArray = new Array<Goal>(2);
        oreArray.InsertAtEnd(new GatheringGoal("gold","mine gold",5));
        oreArray.InsertAtEnd(new GatheringGoal("iron", "mine iron", 8));
        oreContract = new Contract(Contract.ContractType.mining,oreArray);
        oreContract.goals = oreArray;
        inventory.AddOre(new OreStack("gold",5));
        inventory.AddOre(new OreStack("iron",9));
    /*   inventory.AddContract(oreContract);
        Debug.Log(oreContract.HasResourcesRequired(inventory));
        oreContract.GatherResources(inventory);
        foreach (ContractResource<OreStack> s in oreContract.resources)
        {
            Debug.Log(s.resource);
        }

        enemyContract = new Contract<EnemyKill>(Contract<EnemyKill>.ContractType.combat, new ContractResource<EnemyKill>(,) {new ContractResource<EnemyKill>(,) });*/

        


    }

    // Update is called once per frame
    void Update()
    {
        
    }

}