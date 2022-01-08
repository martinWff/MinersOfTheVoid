using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContractGenerator : MonoBehaviour
{
    public static Array<Contract> contracts = new Array<Contract>(4);
    public delegate void ContractGenerated(Contract contract);
    public static event ContractGenerated onContractGenerated;
    private bool bossContractGenerated = false;
    // Start is called before the first frame update
    void Awake()
    {
        
        ContractManager.onContractFinished += ContractManager_onContractFinished;
        ContractManager.onContractFinished += WinBoss;


    }

    private void Start()
    {
        ProcessContractGeneration();
    }

    private void ContractManager_onContractFinished(Contract contract)
    {
        if (contracts.Contains(contract))
        {
            contracts.Remove(contract);
        }
        ProcessContractGeneration();
    }

    private void ProcessContractGeneration()
    {
        if (contracts.Count < contracts.Length)
        {
           
           contracts.InsertAtEnd(GenerateRandomContract());
            ProcessContractGeneration();
            
        }
    }
    private void OnDestroy()
    {
        ContractManager.onContractFinished -= ContractManager_onContractFinished;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

    public Contract GenerateBossContract()
    {
        
        Array<Goal> arr = new Array<Goal>(1);
        arr.InsertAtEnd(new KillGoal("boss", "Kill the Boss", 1,null));

        Contract c = new Contract(Contract.ContractType.position, arr);
        c.bips = 120;
        //Debug.Log("something");
        return c;

    }

    private void WinBoss(Contract c)
    {
        if (c.contractType == Contract.ContractType.position)
        {
            SavePlayerStats.level++;
        }
    }

    public Contract GenerateGatherContract()
    {
        int numberOfGoals = Random.Range(1, 4);
        Array<Goal> arr = new Array<Goal>(numberOfGoals);


        List<string> oresToUse = new List<string>(OreManager.instance.ores.Length);
        foreach (OreResourceObject element in OreManager.instance.GetOreResourcesObjets())
        {
            oresToUse.Add(element.oreName);
        }
        
        for (int i = 0; i < numberOfGoals; i++)
        {


           int oreIndex = Random.Range(0, oresToUse.Count-1);
            
            OreResourceObject rs = OreManager.instance.GetOreResourceByName(oresToUse[oreIndex]);
            oresToUse.RemoveAt(oreIndex);
 
            int quantity = Random.Range(1, 6);

            arr.InsertAtEnd(new GatheringGoal(OreManager.instance.GetOreMaterialByMaterialName(rs.oreName).GetOreStack(quantity),PlayerInventory.staticInventory));
        }
        Contract c = new Contract(Contract.ContractType.mining, arr);

        c.bips = Random.Range(30, 51);
        c.famePoints = Random.Range(30,41);

        return c;

    }


    public Contract GenerateCombatContract()
    {
        int numberOfGoals = Random.Range(1, 3);
        Array<Goal> arr = new Array<Goal>(numberOfGoals);


        for (int i = 0; i < numberOfGoals; i++)
        {
            int quantity = Random.Range(1, 5);
            int goalType = Random.Range(0, 3);

            EnemyElement enemyElement = UpgradeLoader.instance.enemies[Random.Range(0, UpgradeLoader.instance.enemies.Length)];
            if (goalType <= 1) {
                arr.InsertAtEnd(new KillGoal(enemyElement.enemyName, "Kill {quantity} {name}(s)", quantity, enemyElement.sprite));
            } else {

                int quantityOffset = Random.Range(80, 200);
                arr.InsertAtEnd(new DamageGoal(enemyElement.enemyName, "Deal {quantity} damage to {name}",quantity + quantityOffset, enemyElement.sprite));
            }
        }
        Contract c = new Contract(Contract.ContractType.combat, arr);

        c.bips = Random.Range(30, 51);
        c.famePoints = Random.Range(30, 41);

        return c;

    }

    public Contract GenerateRandomContract()
    {
        return GenerateBossContract();

        if (SavePlayerStats.rp < 5)
        {
            return GenerateCommonContracts();
        }
        else
        {
            if (!bossContractGenerated)
            {
                bossContractGenerated = true;
                return GenerateBossContract();
            } else
            {
                return GenerateCommonContracts();
            }
        }



      
    }

    public Contract GenerateCommonContracts()
    {
        int choice = Random.Range(0, 5);

        if (choice < 3)
        {
            return GenerateGatherContract();
        }
        else
        {
            return GenerateCombatContract();
        }
    }

}
