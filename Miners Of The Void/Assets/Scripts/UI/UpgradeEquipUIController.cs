using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeEquipUIController : MonoBehaviour
{
    [SerializeField] Sprite defSprite;
    public UpgradeController controller;
    [SerializeField] private Image[] slots;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        for (int i = 0;i<slots.Length;i++)
        {
            Upgrade upgrade = controller.upgradeHolder[i];
            slots[i].sprite = upgrade == null ? defSprite : upgrade.sprite;
        }
    }

    public void OnUpgradePlaced(int index,Upgrade upgrade)
    {
        slots[index].sprite = upgrade.sprite;
        slots[index].GetComponentInChildren<Text>().text = upgrade.level.ToString();
    }

    public void OnUpgradeRemoved(int index,Upgrade upgrade)
    {
        slots[index].sprite = defSprite;
        slots[index].GetComponentInChildren<Text>().text = null;
    }
}
