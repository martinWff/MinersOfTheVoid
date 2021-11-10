using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContractTest : MonoBehaviour
{
    public Inventory inventory;


    public Contract oreContract;

    public Sprite goldSprite;
    public Sprite ironSprite;
    public Sprite copperSprite;

    public ContractGenerator contractGenerator;
    public Contract currentContract;


    //  public Text textOutput;


    // public Contract<EnemyKill> enemyContract;
    // Start is called before the first frame update
    void Start()
    {
        inventory = new Inventory();
        //inventory.contractFilter = new Dictionary<string, int>() { { "gold", 15 }, { "iron", 8 } };
        inventory.AddContractInventoryFilter("gold", 15);
        inventory.AddContractInventoryFilter("iron", 20);
        /* Array<Goal> oreArray = new Array<Goal>(2);
         oreArray.InsertAtEnd(new GatheringGoal("gold", "mine 5 gold", 15) {sprite= goldSprite});
         oreArray.InsertAtEnd(new GatheringGoal("iron", "mine 8 iron", 20) { sprite = ironSprite });
         oreContract = new Contract(Contract.ContractType.mining,oreArray);*



         ContractManager.AcceptContract(oreContract);

         oreContract.Start();*/

        currentContract = contractGenerator.GenerateBossContract();
        ContractManager.AcceptContract(currentContract);
        currentContract.Start();






    }


    // Update is called once per frame
    void Update()
    {
        //oreContract.CheckGoals();

        if (Input.GetKeyDown(KeyCode.G))
        {

            /* inventory.AddOre(new OreStack("gold", 1,goldSprite));
             inventory.AddOre(new OreStack("iron", 1,ironSprite));
             inventory.AddOre(new OreStack("copper", 1, copperSprite));*/
            if (currentContract.goals.Get(1).currentAmount < currentContract.goals.Get(1).requiredAmount)
            {
                currentContract.goals.Get(1).currentAmount += 1;
                currentContract.goals.Get(1).Evaluate();
            }

        }

        if (Input.GetKeyDown(KeyCode.F))
        {
          /*  inventory.RetrieveAmount("gold", 1);
            inventory.RetrieveAmount("iron", 1);
            inventory.RetrieveAmount("diamond", 1);*/
            inventory.ClearContractInventory();
        }
    }

}