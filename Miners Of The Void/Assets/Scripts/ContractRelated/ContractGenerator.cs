using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContractGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GenerateGatherContract();
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
        Array<Goal> arr = new Array<Goal>(2);

        OreResourceObject[] ores = OreManager.instance.GetOreResourcesObjets();
        OreResourceObject rs = ores[Random.Range(0, ores.Length-1)];
        Debug.Log(rs);

        arr.InsertAtEnd(new GatheringGoal(OreManager.instance.GetOreMaterialByMaterialName(rs.oreName).GetOreStack()));
        Contract c = new Contract(Contract.ContractType.mining, arr);

        return c;

    }

    private void PickGatherGoal()
    {
       // GatheringGoal g = new GatheringGoal("iron", "mine 3 gold", Random.Range(0, 5));
    }

}
