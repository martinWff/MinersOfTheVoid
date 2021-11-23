using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class OreStack : IResourceEqual {

    public string oreName;

    public Sprite sprite;

    public int amount;

    public OreStack(string oreName,int amount = 1)
    {
        this.oreName = oreName;
        this.amount = amount;
    }

    public OreStack(string oreName, int amount,Sprite sprite)
    {
        this.oreName = oreName;
        this.amount = amount;
        this.sprite = sprite;
    }

    public int? CompareDifference(object obj)
    {
        int? value = null;
        OreStack otherOreStack = (OreStack)obj;
        if (otherOreStack != null)
        {



            value = Mathf.Abs(this.amount - otherOreStack.amount);

        }
        return value;

    }

    public bool IsSimilar(object obj)
    {
        OreStack otherOreStack = (OreStack)obj;
        if (otherOreStack == null) return false;
        if (otherOreStack.oreName == this.oreName && otherOreStack.amount == this.amount && otherOreStack.sprite == this.sprite) {

            return true;
        } else
        {
            return false;
        }


        
    }

 
    /* public bool IsSimilar()
     {
         OreStack otherOreStack = (OreStack)obj;

         if (otherOreStack.oreName ==)


             return
     }*/

    public override string ToString()
    {
        return $"OreStack {oreName}, x{amount}";
    }

}


public class ContractResource<T> where T : IResourceEqual
{
    public T resource;
    public T gathered;

    public ContractResource(T res,T gath)
    {
        resource = res;
        gathered = gath;
    }
    public ContractResource(T res)
    {
        resource = res;
    }

    public bool CompareEquality()
    {
        return resource.IsSimilar(gathered);
    }

    public int CompareDifference()
    {
        return (int)resource.CompareDifference(gathered);
    }

}


public class EnemyKill : IResourceEqual
{
    public string enemyName;

    public int kills;


    public bool IsSimilar(object obj)
    {
        EnemyKill otherEnemyKills = (EnemyKill)obj;
        if (otherEnemyKills == null) return false;
        if (otherEnemyKills.kills == this.kills && otherEnemyKills.enemyName == this.enemyName)
        {
            return true;
        } else
        {
            return false;
        }


    }

    public int? CompareDifference(object obj)
    {
        if (obj != null && obj is EnemyKill)
        {

            return Mathf.Abs(kills - (obj as EnemyKill).kills);
        } else
        {
            return null;
        }
    }


}


public interface IResourceEqual
{
    bool IsSimilar(object obj);
    int? CompareDifference(object obj);
}