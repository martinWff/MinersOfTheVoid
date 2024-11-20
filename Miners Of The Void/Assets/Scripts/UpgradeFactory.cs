using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeFactory : MonoBehaviour
{
    public List<UpgradeElement> elements = new List<UpgradeElement>();
    private static UpgradeFactory instance;

    private void Awake()
    {
        instance = this;
    }

    public static Upgrade GenerateUpgrade(string id,string name,int level)
    {
        Upgrade upg = (Upgrade)System.Activator.CreateInstance(System.Type.GetType(id),name,level);

        if (upg != null)
        {
           // upg.level = level;
            upg.sprite = instance.elements.Find((UpgradeElement e) => e.id == id).sprite;
        }
        return upg;
    }

    [System.Serializable]
    public struct UpgradeElement
    {
        public string id;
        public Sprite sprite;
    }
}
