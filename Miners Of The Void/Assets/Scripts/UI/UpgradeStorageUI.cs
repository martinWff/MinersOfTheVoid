using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeStorageUI : MonoBehaviour
{
    public UpgradeStorage storage;
    public UpgradeController controller;

    public Transform frame;

    [SerializeField] GameObject buttonPrefab;

    private List<GameObject> buttons = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        List<Upgrade> unlockedUpgrades = storage.unlockedUpgrades;
        for (int i = 0;i<unlockedUpgrades.Count;i++)
        {
            CreateButton(unlockedUpgrades[i]);
        }
    }

    private GameObject CreateButton(Upgrade upgrade)
    {
        GameObject g = Instantiate(buttonPrefab, frame);
        g.GetComponentInChildren<Text>().text = upgrade.upgradeName;
        EquipUpgradeButton equip = g.GetComponent<EquipUpgradeButton>();
        equip.upgrade = upgrade;
        equip.controller = controller;

        buttons.Add(g);

        return g;
    }

    private void OnDisable()
    {
        for (int i = 0;i<buttons.Count;i++)
        {
            Destroy(buttons[i]);
        }

        buttons.Clear();
    }
}
