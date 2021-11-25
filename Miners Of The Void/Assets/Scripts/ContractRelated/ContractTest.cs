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
    private void Awake()
    {
        inventory = new Inventory();
    //    InventoryController.onInventoryControllerCreated += InventoryController_onInventoryControllerCreated;
    }


    void Start()
    {
        // InventoryManager im = FindObjectOfType<InventoryManager>();
       
       
        //controller.inventory = new Inventory();
        inventory.AddOre(new OreStack("Coal", 1, copperSprite));
        Array<Goal> g = new Array<Goal>(1);
        g.InsertAtEnd(new GatheringGoal("Iron", "mine 1 iron", 1,ironSprite));
        oreContract = new Contract(Contract.ContractType.mining, g);
        oreContract.goals = g;
      

        ContractManager.AcceptContract(oreContract);
        oreContract.Start();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            inventory.AddOre(new OreStack("Iron",1,ironSprite));
        }
    }

}