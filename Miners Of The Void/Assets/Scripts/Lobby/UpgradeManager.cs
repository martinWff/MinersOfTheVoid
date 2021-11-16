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
        //Array<string> mySlots;
        public GameObject slot1;
        public GameObject slot2;
        public GameObject slot3;
        public GameObject slot4;
        public GameObject insertGO;
        private bool imageIn = false;
        private bool full = false;



        // Start is called before the first frame update
        void Start()
        {
            player = GameObject.FindGameObjectWithTag("Spaceship");
           // mySlots = new Array<string>(4);
            playerstats = player.GetComponent<SpaceshipMovement>();
            slot1 = GameObject.Find("Slot1");
            slot2 = GameObject.Find("Slot2");
            slot3 = GameObject.Find("Slot3");
            slot4 = GameObject.Find("Slot4");
            
        }

        
        public void ASummon()
        {
            
                if (!imageIn)
                {
                    if (slot1.transform.childCount == 0)
                    {
                        Instantiate(insertGO, slot1.transform);
                        full = false;
                    }
                    else if (slot2.transform.childCount == 0)
                    {
                        Instantiate(insertGO, slot2.transform);
                        full = false;
                    }
                    else if (slot3.transform.childCount == 0)
                    {
                        Instantiate(insertGO, slot3.transform);
                        full = false;
                    }
                    else if (slot4.transform.childCount == 0)
                    {
                        Instantiate(insertGO, slot4.transform);
                        full = false;
                        Debug.Log(full);
                    }
                    else
                    {
                        Debug.Log(full);
                        full = true;
                    }
                    imageIn = true;
                }
            if (full == false)
            {
                if (upgradeType == "SpeedButton")
                {
                    level = playerstats.speedLevel;
                    AddUpgrade(new Speed("speed"));
                    
                  //  mySlots.InsertAtEnd("speed");
                   
                    
                }
                if (upgradeType == "ShieldButton")
                {
                    level = playerstats.shieldLevel;
                    AddUpgrade(new Shield("shield"));
                //  mySlots.InsertAtEnd("shield");


            }
                if (upgradeType == "HealthButton")
                {
                    level = playerstats.healthLevel;
                AddUpgrade(new Hp("health"));
                // mySlots.InsertAtEnd("health");
                // mySlots.InsertAtEnd("shield");
            }
                if (upgradeType == "BackWeapon")
                {
                
                AddUpgrade(new BackWeapon("backweapon"));
                //mySlots.InsertAtEnd("backWeapon");
            }
            if (upgradeType == "DmgButton")
            {
                level = playerstats.dmgLevel;
                AddUpgrade(new Dmg("dmg"));
                //mySlots.InsertAtEnd("backWeapon");
            }

                
            }
            /*Debug.Log(mySlots.Get(0));
            Debug.Log(mySlots.Get(1));
            Debug.Log(mySlots.Get(2));
            Debug.Log(mySlots.Get(3));*/
        }
        public void UnSummon()
        {
            
            
            if (upgradeType == "SpeedButton")
            {
                level = playerstats.speedLevel;
                RemoveUpgrade(new Speed("speed"));
                
                
                //  mySlots.InsertAtEnd("speed");
            }
            if (upgradeType == "ShieldButton")
            {
                level = playerstats.shieldLevel;
                RemoveUpgrade(new Shield("shield"));
                //  mySlots.InsertAtEnd("shield");
                


            }
            if (upgradeType == "HealthButton")
            {
                level = playerstats.healthLevel;
                RemoveUpgrade(new Hp("health"));
                // mySlots.InsertAtEnd("health");
                // mySlots.InsertAtEnd("shield");
                
            }
            if (upgradeType == "BackWeapon")
            {
                RemoveUpgrade(new BackWeapon("backweapon"));
                
                //mySlots.InsertAtEnd("backWeapon");
            }
            if (upgradeType == "DmgButton")
            {
                level = playerstats.dmgLevel;
                RemoveUpgrade(new Dmg("dmg"));
                //mySlots.InsertAtEnd("backWeapon");
            }
            Debug.Log(upgradeType);
            GameObject.Find(upgradeType).GetComponent<UpgradeManager>().imageIn = false;
            Debug.Log(GameObject.Find(upgradeType).GetComponent<UpgradeManager>().imageIn);
            Destroy(gameObject);
            
        }
        public void RemoveUpgrade(Upgrade upg)
        {
            upg.OnRemove();
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
            GameObject.FindGameObjectWithTag("Spaceship").GetComponent<SpaceshipMovement>().totalShield = 10 * (level + 1);
            GameObject.FindGameObjectWithTag("Spaceship").GetComponent<SpaceshipMovement>().shieldLevel += 1;
        }
        else
        {
            GameObject.FindGameObjectWithTag("Spaceship").GetComponent<SpaceshipMovement>().totalShield = 10 * level;
            Debug.Log("Max level reached!");
        }
    

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

    public override void OnPut(float level)
        {
        if (level < 6)
        {

            GameObject.FindGameObjectWithTag("Spaceship").GetComponent<SpaceshipMovement>().hp = 20 * (level + 1);
            GameObject.FindGameObjectWithTag("Spaceship").GetComponent<SpaceshipMovement>().healthLevel += 1;
        }
        else
        {
            GameObject.FindGameObjectWithTag("Spaceship").GetComponent<SpaceshipMovement>().hp = 20 * level;
            Debug.Log("Max level reached!"); 
        }
    }
        public override void OnUpdate()
        {
            throw new System.NotImplementedException();
        }
        public override void OnRemove()
        {
        GameObject.FindGameObjectWithTag("Spaceship").GetComponent<SpaceshipMovement>().hp = 20;
    }

    }
    public class Dmg : Upgrade
    {
    public Dmg(string upName) : base(upName)
    {
    }

    public override void OnPut(float level)
        {
        if (level < 6)
        {

            GameObject.FindGameObjectWithTag("Spaceship").GetComponent<SpaceshipMovement>().playerDamage = 10 * (level + 1);
            GameObject.FindGameObjectWithTag("Spaceship").GetComponent<SpaceshipMovement>().dmgLevel += 1;
        }
        else
        {
            GameObject.FindGameObjectWithTag("Spaceship").GetComponent<SpaceshipMovement>().playerDamage = 10 * level;
            Debug.Log("Max level reached!");
        }
    }
        public override void OnUpdate()
        {
            throw new System.NotImplementedException();
        }
        public override void OnRemove()
        {
        GameObject.FindGameObjectWithTag("Spaceship").GetComponent<SpaceshipMovement>().playerDamage = 10;
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
        
            GameObject.FindGameObjectWithTag("Spaceship").GetComponent<SpaceshipMovement>().backweaponMode = false;
       
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
            GameObject.FindGameObjectWithTag("Spaceship").GetComponent<SpaceshipMovement>().moveForce = 4 * (level + 1);
            GameObject.FindGameObjectWithTag("Spaceship").GetComponent<SpaceshipMovement>().bulletSpeed = 20 + (3 * (level + 1));
            GameObject.FindGameObjectWithTag("Spaceship").GetComponent<SpaceshipMovement>().speedLevel += 1;
        }
        else
        {
            GameObject.FindGameObjectWithTag("Spaceship").GetComponent<SpaceshipMovement>().moveForce = 4 * level;
            GameObject.FindGameObjectWithTag("Spaceship").GetComponent<SpaceshipMovement>().bulletSpeed = 20 + (3 * level);
            Debug.Log("Limit reached");
        }
    }
    public override void OnUpdate()
        {
            throw new System.NotImplementedException();
    }
        public override void OnRemove()
        {
        GameObject.FindGameObjectWithTag("Spaceship").GetComponent<SpaceshipMovement>().moveForce = 4;
        GameObject.FindGameObjectWithTag("Spaceship").GetComponent<SpaceshipMovement>().bulletSpeed = 20;
    }

    }
public class Zoom : Upgrade
{
    public Zoom(string upName) : base(upName)
    {
    }

    public override void OnPut(float level)
    {
        if (level < 6)
        {
            GameObject.FindGameObjectWithTag("Spaceship").GetComponent<SpaceshipMovement>().moveForce = 4 * (level + 1);
            GameObject.FindGameObjectWithTag("Spaceship").GetComponent<SpaceshipMovement>().bulletSpeed = 20 + (3 * (level + 1));
            GameObject.FindGameObjectWithTag("Spaceship").GetComponent<SpaceshipMovement>().speedLevel += 1;
        }
        else
        {
            GameObject.FindGameObjectWithTag("Spaceship").GetComponent<SpaceshipMovement>().moveForce = 4 * level;
            GameObject.FindGameObjectWithTag("Spaceship").GetComponent<SpaceshipMovement>().bulletSpeed = 20 + (3 * level);
            Debug.Log("Limit reached");
        }
    }
    public override void OnUpdate()
    {
        throw new System.NotImplementedException();
    }
    public override void OnRemove()
    {
        GameObject.FindGameObjectWithTag("Spaceship").GetComponent<SpaceshipMovement>().moveForce = 4;
        GameObject.FindGameObjectWithTag("Spaceship").GetComponent<SpaceshipMovement>().bulletSpeed = 20;
    }

}
