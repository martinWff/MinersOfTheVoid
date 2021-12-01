using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


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
        public Sprite insertGO;
        private bool imageIn = false;
        private bool full = false;
        public bool human = false;
        public PlayerMovement humanStats;
        public UpgradeInv upinv;
        public UpgradeInv inventory;
        public PlayerInventory invPlayer;
        public Text notices;
        public Text bipText;


        // Start is called before the first frame update
        void Start()
        {
            player = GameObject.FindGameObjectWithTag("Spaceship");
            upinv = GameObject.Find("Image").GetComponent<UpgradeInv>();
           // mySlots = new Array<string>(4);
            playerstats = player.GetComponent<SpaceshipMovement>();
            humanStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
            slot1 = GameObject.Find("Slot1");
            slot2 = GameObject.Find("Slot2");
            slot3 = GameObject.Find("Slot3");
            slot4 = GameObject.Find("Slot4");
            inventory = FindObjectOfType<UpgradeInv>();
            invPlayer = GameObject.FindGameObjectWithTag("PlayerInventory").GetComponent<PlayerInventory>();
            playerstats.LoadStats();
            notices = GameObject.Find("Notices").GetComponent<Text>();
            bipText = GameObject.Find("Bips").GetComponent<Text>();
            notices.text = "Welcome to the upgrades!";
            
            
            
            
        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.L)) Debug.Log(invPlayer.inventory.GetOreAmount("Iron"));
        }

        public void ASummon()
        {
          if (!human) { 
              /*  if (!imageIn)
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
                }*/

            
                    if (upgradeType == "SpeedButton")
                    {
                        level = SavePlayerStats.speedLevel;
                        Debug.Log(level);
                        if (inventory.ContainsOre(upgradeType) || (!inventory.ContainsOre(upgradeType) && level ==0))
                        {
                        if (level < 6) {
                            if (AddCost("Gold", "Copper Nugget", "Iron Ingot", 200, (int)level))
                            {
                                Debug.Log("Com custos");
                                AddUpgrade(new Speed(upgradeType), false);
                                inventory.AddUpgradeVisual(upgradeType, level, insertGO, false);
                            }
                        }
                        }
                        if(!inventory.ContainsOre(upgradeType) && level != 0)
                        {
                            notices.text = "No cost for this operation";
                            AddUpgrade(new Speed(upgradeType),true);
                            inventory.AddUpgradeVisual(upgradeType, level -1, insertGO,false);
                        }
                       
                    }
                    if (upgradeType == "ShieldButton")
                {
                    level = SavePlayerStats.shieldLevel;
                        if (inventory.ContainsOre(upgradeType) || (!inventory.ContainsOre(upgradeType) && level == 0))
                        {
                        if (level < 6)
                        {
                            if (AddCost("Osmium", "Iron Nugget", "Copper Ingot", 200, (int)level))
                            {
                                Debug.Log("Com custos");
                                AddUpgrade(new Shield(upgradeType), false);
                                inventory.AddUpgradeVisual(upgradeType, level, insertGO, false);
                            }
                        }
                        }
                        if (!inventory.ContainsOre(upgradeType) && level != 0)
                        {
                            notices.text = "No cost for this operation";
                            AddUpgrade(new Shield(upgradeType), true);
                            inventory.AddUpgradeVisual(upgradeType, level - 1, insertGO,false);
                        };


                    }
                if (upgradeType == "HealthButton")
                {
                    level = SavePlayerStats.healthLevel;
                        if (inventory.ContainsOre(upgradeType) || (!inventory.ContainsOre(upgradeType) && level == 0))
                        {
                        if (level < 6)
                        {
                            if ((AddCost("Gold", "Copper Nugget", "Iron Ingot", 200, (int)level)))
                            {
                                Debug.Log("Com custos");
                                AddUpgrade(new Hp(upgradeType), false);
                                inventory.AddUpgradeVisual(upgradeType, level, insertGO, false);
                            }
                        }
                        }
                        if (!inventory.ContainsOre(upgradeType) && level != 0 )
                        {
                            notices.text = "No cost for this operation";
                            AddUpgrade(new Hp(upgradeType), true);
                            inventory.AddUpgradeVisual(upgradeType, level - 1, insertGO,false);
                        }
                    }
                if (upgradeType == "BackWeapon")
                {

                    if ((!inventory.ContainsOre(upgradeType) && !SavePlayerStats.backWeaponAquired))
                    {

                        if (AddCost("Gold", "Osmium Nugget", "Iron Ingot", 2000, 3) && level < 6)
                        {

                            AddUpgrade(new BackWeapon(upgradeType), false);
                            inventory.AddUpgradeVisual(upgradeType, 1, insertGO, true);
                            SavePlayerStats.backWeaponAquired = true;
                        }

                    }
                    else { notices.text = "No costs"; inventory.AddUpgradeVisual(upgradeType, 1, insertGO, true); AddUpgrade(new BackWeapon(upgradeType), false); }
                    
                    //mySlots.InsertAtEnd("backWeapon");
                }
                /*if (upgradeType == "DmgButton")
                {
                    level = SavePlayerStats.dmgLevel;
                        if (inventory.ContainsOre(upgradeType) || (!inventory.ContainsOre(upgradeType) && level == 0))
                        {

                            if (AddCost("Gold", "Copper Nugget", "Iron Ingot", 200, (int)level))
                            {
                                Debug.Log("Com custos");
                                AddUpgrade(new Dmg(upgradeType), false);
                                inventory.AddUpgradeVisual(upgradeType, level, insertGO);
                            }
                        }
                        if (!inventory.ContainsOre(upgradeType) && level != 0)
                        {
                            Debug.Log("Sem custos");
                            AddUpgrade(new Dmg(upgradeType), true);
                            inventory.AddUpgradeVisual(upgradeType, level - 1, insertGO);
                        }
                    }*/
                
                
            }
            else
            {
                if (upgradeType == "SpeedButton")
                {
                    level = humanStats.speedLevel;
                   

                    if (SavePlayerStats.bips >= 200 * level)
                    {
                        AddUpgrade(new Speed("speed"), false);
                        notices.text = ("Aquiered!");
                    }
                    else notices.text = ("You can't afford to buy this upgrade, " + 200 * level+1 +" bips needed");
                    //  mySlots.InsertAtEnd("speed");


                }
                if (upgradeType == "ShieldButton")
                {
                    level = humanStats.shieldLevel;

                    
                    //  mySlots.InsertAtEnd("shield");
                    if (SavePlayerStats.bips >= 200 * level)
                    {
                        AddUpgrade(new Shield("shield"), false);
                        notices.text = ("Aquiered!");
                    }
                    else notices.text =("You can't afford to buy this upgrade.");


                }
                if (upgradeType == "HealthButton")
                {
                    level = humanStats.healthLevel;
                    if (SavePlayerStats.bips >= 200 * level)
                    {
                        AddUpgrade(new Hp("health"), false);
                        notices.text = ("Aquiered!");
                    }
                    else notices.text =("You can't afford to buy this upgrade.");
                    
                    // mySlots.InsertAtEnd("health");
                    // mySlots.InsertAtEnd("shield");
                }
                /*  if (upgradeType == "DmgButton")
                  {
                      level = humanStats.dmgLevel;
                      AddUpgrade(new Dmg("dmg"), false);
                      //mySlots.InsertAtEnd("backWeapon");
                  }*/
              
                
            }
            playerstats.SaveStats();
            bipText.text = "Bips: " + SavePlayerStats.bips;

        }
        public void UnSummon(string upgradeType)
        {
            
            
            if (upgradeType == "SpeedButton")
            {
                RemoveUpgrade(new Speed(upgradeType));
                inventory.RemoveUpgrade(upgradeType);


                //  mySlots.InsertAtEnd("speed");
            }
            if (upgradeType == "ShieldButton")
            {
                level = playerstats.shieldLevel;
                RemoveUpgrade(new Shield("shield"));
                inventory.RemoveUpgrade(upgradeType);
                //  mySlots.InsertAtEnd("shield");



            }
            if (upgradeType == "HealthButton")
            {
                level = playerstats.healthLevel;
                RemoveUpgrade(new Hp("health"));
                inventory.RemoveUpgrade(upgradeType);
                // mySlots.InsertAtEnd("health");
                // mySlots.InsertAtEnd("shield");

            }
            if (upgradeType == "BackWeapon")
            {
                RemoveUpgrade(new BackWeapon("backweapon"));
                inventory.RemoveUpgrade(upgradeType);

                //mySlots.InsertAtEnd("backWeapon");
            }
          /*  if (upgradeType == "DmgButton")
            {
                
                RemoveUpgrade(new Dmg("dmg"));
                inventory.RemoveUpgrade(upgradeType);
                //mySlots.InsertAtEnd("backWeapon");
            }
            Debug.Log(upgradeType);
            GameObject.Find(upgradeType).GetComponent<UpgradeManager>().imageIn = false;
            Debug.Log(GameObject.Find(upgradeType).GetComponent<UpgradeManager>().imageIn);
            */
            
        }
        public bool AddCost(string material1, string material2,string material3,int bips,int level)
        {
            if (invPlayer.inventory.GetOreAmount(material1) >= level + 1 && invPlayer.inventory.GetOreAmount(material2) >= level + 1 && invPlayer.inventory.GetOreAmount(material3) >= level + 1 && SavePlayerStats.bips >= (bips * ((int)level +1)))
            {
                
                invPlayer.inventory.RetrieveAmount(material1, level + 1);
                invPlayer.inventory.RetrieveAmount(material2, level + 1);
                invPlayer.inventory.RetrieveAmount(material3, level + 1);
                SavePlayerStats.bips -= (bips * (int)level);
                notices.text = "Aquiered!";
                return true;
            }
            else
            {
                notices.text = "Not enough ore: " + material1 + ":" + invPlayer.inventory.GetOreAmount(material1) + "; "+material2 + ":" + invPlayer.inventory.GetOreAmount(material2) + material3 + ":" + invPlayer.inventory.GetOreAmount(material3)+", you need at least "+level + 1+" of each.";
                return false;
            }
        }
        public void RemoveUpgrade(Upgrade upg)
        {
            upg.OnRemove();
        }
        public void AddUpgrade(Upgrade upg, bool isBought)
        {
            upg.OnPut(level, human, isBought);
        }
        
        
        
    }
    
}


    public abstract class Upgrade
    {
        
       public string upgradeName;

    public abstract void OnPut(float level, bool who, bool replacing);

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

    public override void OnPut(float level, bool who, bool bought)
    {
        if (!who)
        {
            if (level < 6 && !bought)
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
        else
        {
            if (level < 6)
            {
                
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().totalShield = 10 * (level + 1);
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().shieldLevel += 1;
            }
            else
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().totalShield = 10 * level;
                Debug.Log("Max level reached!");
            }
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

    public override void OnPut(float level, bool who, bool bought)
    {
        if (!who)
        {
            if (level < 6 && !bought)
            {

                GameObject.FindGameObjectWithTag("Spaceship").GetComponent<SpaceshipMovement>().hp = 20 * (level + 1);
                GameObject.FindGameObjectWithTag("Spaceship").GetComponent<SpaceshipMovement>().totalhp = 20 * (level + 1);
                GameObject.FindGameObjectWithTag("Spaceship").GetComponent<SpaceshipMovement>().healthLevel += 1;
            }
            else
            {
                GameObject.FindGameObjectWithTag("Spaceship").GetComponent<SpaceshipMovement>().hp = 20 * level;
                GameObject.FindGameObjectWithTag("Spaceship").GetComponent<SpaceshipMovement>().totalhp = 20 * level;
                Debug.Log("Max level reached!");
            }
        }
        else
        {
            if (level < 6)
            {

                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().hp = 10 * (level + 1);
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().healthLevel += 1;
            }
            else
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().hp = 20 * level;
                Debug.Log("Max level reached!");
            }
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

    public override void OnPut(float level, bool who, bool bought)
        {
        if (!who)
        {
            if (level < 6 && !bought)
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
        else
        {
            if (level < 6)
            {

                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().playerDamage = 10 * (level + 1);
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().dmgLevel += 1;
            }
            else
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().playerDamage = 10 * level;
                Debug.Log("Max level reached!");
            }
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

    public override void OnPut(float level, bool who, bool bought)
        {
        if (!who)
        {
            if (GameObject.FindGameObjectWithTag("Spaceship").GetComponent<SpaceshipMovement>().backweaponMode == false)
                GameObject.FindGameObjectWithTag("Spaceship").GetComponent<SpaceshipMovement>().backweaponMode = true;
            else Debug.Log("You already bought your backweapon!");
        }

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

    public override void OnPut(float level, bool who, bool bought)
        {
        if (!who)
        {
            if (level < 6 && !bought)
            {
                GameObject.FindGameObjectWithTag("Spaceship").GetComponent<SpaceshipMovement>().moveForce = 8 +( 4 * (level + 1));
                GameObject.FindGameObjectWithTag("Spaceship").GetComponent<SpaceshipMovement>().bulletSpeed = 20 + (3 * (level + 1));
                GameObject.FindGameObjectWithTag("Spaceship").GetComponent<SpaceshipMovement>().speedLevel += 1;
            }
            else
            {
                GameObject.FindGameObjectWithTag("Spaceship").GetComponent<SpaceshipMovement>().moveForce = 4 * level;
                GameObject.FindGameObjectWithTag("Spaceship").GetComponent<SpaceshipMovement>().bulletSpeed = 20 + (3 * level);
                
            }
        }
        else
        {
            if (level < 6)
            {

                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().moveForce = 4 * (level + 1);
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().bulletSpeed = 20 + (3 * (level + 1));
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().speedLevel += 1;
            }
            else
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().moveForce = 4 * level;
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().bulletSpeed = 20 + (3 * level);
                Debug.Log("Max level reached!");
            }
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

