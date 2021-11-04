using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MOV.Upgrades
{
    public class UpgradeManager : MonoBehaviour
    {
        GameObject player;
        SpaceshipMovement playerstats;
        Array<Upgrade> upgrades = new Array<Upgrade>(4);
        public Upgrade[] upgrade = new Upgrade[4];
        public string upgradeType;
        private float level;
        Array<string> mySlots = new Array<string>(4);
       



        // Start is called before the first frame update
        void Start()
        {
            player = GameObject.FindGameObjectWithTag("Spaceship");

            playerstats = player.GetComponent<SpaceshipMovement>();
            

        }

        // Update is called once per frame
        void Update()
        {

        }
        
        public void ASummon()
        {
           // if (mySlots.Length < 4)
           // {
                if (upgradeType == "Speed")
                {
                    level = playerstats.speedLevel;
                    AddUpgrade(new Speed("speed"));
                    mySlots.InsertAtEnd("speed");
                }
                if (upgradeType == "Shield")
                {
                    level = playerstats.shieldLevel;
                    AddUpgrade(new Shield("shield"));
                    mySlots.InsertAtEnd("shield");
                  
                    
                }
                if (upgradeType == "Health")
                {
                    level = playerstats.healthLevel;
           
                    AddUpgrade(new Hp("health"));
                    
                }
                if (upgradeType == "BackWeapon")
                {
                  
                    AddUpgrade(new BackWeapon("backweapon"));

                    
                }
            // } else Debug.Log("All Slots full");





        }
        public void AddUpgrade(Upgrade upg)
        {

            upg.OnPut(level);

        }
    }
}


    public abstract class Upgrade
    {
        
       public string upgradeName;

        public abstract void OnPut(float level);

        public abstract void OnUpdate();

        public abstract void OnRemove();


        public Upgrade(string upName)
        {
            upgradeName = upName;
        }

    }
    public class Shield : Upgrade
    {
    public Shield(string upName) : base(upName)
    {
    }

    public override void OnPut(float level)
    {
        if (level < 6)
        {
            GameObject.FindGameObjectWithTag("Spaceship").GetComponent<SpaceshipMovement>().totalShield += 10;
            GameObject.FindGameObjectWithTag("Spaceship").GetComponent<SpaceshipMovement>().shieldLevel += 1;
        }
        else Debug.Log("Max level reached!");
    

        }
        public override void OnUpdate()
        {
        throw new System.NotImplementedException();
    }
        public override void OnRemove()
        {
            throw new System.NotImplementedException();
        }
        
    }
    public class Hp : Upgrade
    {
    public Hp(string upName) : base(upName)
    {
    }

    public override void OnPut(float level)
        {
            if (level < 6)
            {
                GameObject.FindGameObjectWithTag("Spaceship").GetComponent<SpaceshipMovement>().hp += 20;
                GameObject.FindGameObjectWithTag("Spaceship").GetComponent<SpaceshipMovement>().healthLevel += 1;
            }
        else Debug.Log("Max level reached!");
    }
        public override void OnUpdate()
        {
            throw new System.NotImplementedException();
        }
        public override void OnRemove()
        {
            throw new System.NotImplementedException();
        }

    }
    public class Dmg : Upgrade
    {
    public Dmg(string upName) : base(upName)
    {
    }

    public override void OnPut(float level)
        {
        throw new System.NotImplementedException();
    }
        public override void OnUpdate()
        {
            throw new System.NotImplementedException();
        }
        public override void OnRemove()
        {
            throw new System.NotImplementedException();
        }

    }
    public class BackWeapon : Upgrade
    {
    public BackWeapon(string upName) : base(upName)
    {
    }

    public override void OnPut(float level)
        {
        if (GameObject.FindGameObjectWithTag("Spaceship").GetComponent<SpaceshipMovement>().backweaponMode == false)
            GameObject.FindGameObjectWithTag("Spaceship").GetComponent<SpaceshipMovement>().backweaponMode = true;
        else Debug.Log("You already bought your backweapon!");
        }
        public override void OnUpdate()
        {
            throw new System.NotImplementedException();
        }
        public override void OnRemove()
        {
            throw new System.NotImplementedException();
        }

    }
    public class Speed : Upgrade
    {
    public Speed(string upName) : base(upName)
    {
    }

    public override void OnPut(float level)
        {
        if (level < 6)
        {
            GameObject.FindGameObjectWithTag("Spaceship").GetComponent<SpaceshipMovement>().moveForce += 4;
            GameObject.FindGameObjectWithTag("Spaceship").GetComponent<SpaceshipMovement>().bulletSpeed += 3;
            GameObject.FindGameObjectWithTag("Spaceship").GetComponent<SpaceshipMovement>().speedLevel += 1;
        }
        else Debug.Log("Limit reached");
    }
    public override void OnUpdate()
        {
            throw new System.NotImplementedException();
    }
        public override void OnRemove()
        {
            throw new System.NotImplementedException();
        }

    }
