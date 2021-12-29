using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




    public abstract class Upgrade
    {
        
        public string upgradeName;
        public Sprite sprite;
        public int level;
    public int maxLevel;

        public abstract void OnPut(GameObject controller);

        

        public abstract void OnRemove();

       


        public Upgrade(string upName,int _level = 1)
        {
            upgradeName = upName;
            level = _level;
            maxLevel = 6;
        }

        public Upgrade(string upName,int level = 1,int maxLevel = 6)
    {
        upgradeName = upName;
        this.level = level;
        this.maxLevel = maxLevel;
    }

    }
    /*public class Shield : Upgrade
    {
    public Shield(string upName) : base(upName)
    {
    }

        public override void OnPut(GameObject controller)
        {
        
       
    

        }
        public override void OnUpdate()
        {
        throw new System.NotImplementedException();
    }
        public override void OnRemove()
        {
        GameObject.FindGameObjectWithTag("Spaceship").GetComponent<SpaceshipMovement>().totalShield = 10;
    }
        
    }
public class Hp : Upgrade
{
    public Hp(string upName) : base(upName)
    {
    }

    public override void OnPut(GameObject controller)
    {
        throw new System.NotImplementedException();
    }

    public override void OnUpdate()
    {
        throw new System.NotImplementedException();
    }
    public override void OnRemove()
    {
        
    }
}


    public class DamageUpgrade : Upgrade
    {
        public DamageUpgrade(string upName) : base(upName)
        {
               
        }
        public override void OnPut(GameObject controller)
        {
            throw new System.NotImplementedException();
        }

        public override void OnRemove()
        {
            throw new System.NotImplementedException();
        }

        public override void OnUpdate()
        {
            throw new System.NotImplementedException();
        }
    }
    public class BackWeapon : Upgrade
    {
    public BackWeapon(string upName) : base(upName)
    {
    }

    public override void OnPut(GameObject controller)
        {
       
        }
        public override void OnUpdate()
        {
            throw new System.NotImplementedException();
        }
        public override void OnRemove()
        {
        
            GameObject.FindGameObjectWithTag("Spaceship").GetComponent<SpaceshipMovement>().backweaponMode = false;
       
    }

    }*/
    public class SpeedUpgrade : Upgrade
    {
        CharacterMovement characterMovement;
        StatModifier modifier;
    public SpeedUpgrade(string upName,int _level = 1) : base(upName,_level)
    {
        modifier = new StatModifier(4*level,this);
    }


     public override void OnPut(GameObject controller)
      {
        characterMovement = controller.GetComponent<CharacterMovement>();
        characterMovement.movementSpeed.AddModifier(modifier);
        characterMovement.movementSpeed.RemoveAllFromSource(this);
        modifier = new StatModifier(4 * level, this);
        characterMovement.movementSpeed.AddModifier(modifier);
    }

    
    
        public override void OnRemove()
        {
        characterMovement.movementSpeed.RemoveModifier(modifier);
    }


}

