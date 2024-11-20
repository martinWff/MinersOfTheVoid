using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



[System.Serializable]
public abstract class Upgrade
{

    public string upgradeName;
    [System.NonSerialized] public Sprite sprite;
    public int level;
    public int maxLevel;

    public abstract void OnPut(GameObject controller);



    public abstract void OnRemove();




    public Upgrade(string upName, int _level = 1)
    {
        upgradeName = upName;
        level = _level;
        maxLevel = 6;
    }

    public Upgrade(string upName, int level = 1, int maxLevel = 6)
    {
        upgradeName = upName;
        this.level = level;
        this.maxLevel = maxLevel;
    }

}

[System.Serializable]
public struct UpgradeCost
{
    public string name;
    public int quantity;
}


[System.Serializable]
public class SpeedUpgrade : Upgrade
{
    [System.NonSerialized] CharacterMovement characterMovement;
    StatModifier modifier;
    public SpeedUpgrade(string upName, int _level = 1) : base(upName, _level)
    {
        modifier = new StatModifier(4 * level, this);
    }


    public override void OnPut(GameObject controller)
    {
        characterMovement = controller.GetComponent<CharacterMovement>();
        if (characterMovement != null)
        {
            characterMovement.movementSpeed.AddModifier(modifier);
            characterMovement.movementSpeed.RemoveAllFromSource(this);
            modifier = new StatModifier(4 * level, this);
            characterMovement.movementSpeed.AddModifier(modifier);
        }
    }



    public override void OnRemove()
    {

        if (characterMovement != null)
        {
            characterMovement.movementSpeed.RemoveModifier(modifier);
        }

    }


}

