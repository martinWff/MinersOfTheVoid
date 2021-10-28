using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MOV.Upgrades
{
    public class UpgradeManager : MonoBehaviour
    {

        // Start is called before the first frame update
        void Start()
        {



        }

        // Update is called once per frame
        void Update()
        {

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
}