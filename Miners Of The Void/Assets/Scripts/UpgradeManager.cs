using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MOV.Upgrades
{
    public class UpgradeManager : MonoBehaviour
    {
        public Upgrade[] upgrades = new Upgrade[4];
        // Start is called before the first frame update
        void Start()
        {

            AddUpgrade(new SpeedUpgrade("speed"));

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void AddUpgrade(Upgrade upg)
        {
            upg.OnPut();
        }
        
    }


    public abstract class Upgrade
    {
        public string upgradeName;

        public abstract void OnPut();

        public abstract void OnUpdate();

        public abstract void OnRemove();


        public Upgrade(string upName)
        {
            upgradeName = upName;
        }

    }


    public class SpeedUpgrade : Upgrade
    {
        public SpeedUpgrade(string upName) : base(upName)
        {
        }

        public override void OnPut()
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
}