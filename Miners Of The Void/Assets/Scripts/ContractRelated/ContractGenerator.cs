using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContractGenerator : MonoBehaviour
{
    public Array<Contract> contracts = new Array<Contract>(4);
    public delegate void ContractGenerated(Contract contract);
    public static event ContractGenerated onContractGenerated;
    // Start is called before the first frame update
    void Start()
    {

        for (int i = 0; i < contracts.Length; i++)
        {
            contracts.InsertAtEnd(GenerateGatherContract());
        }
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

}
