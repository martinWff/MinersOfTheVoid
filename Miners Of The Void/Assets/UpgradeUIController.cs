using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeUIController : MonoBehaviour
{
    public List<GameObject> upgradeUI = new List<GameObject>(4);

    public Upgrade upgrade;

    public GameObject purchaseWindow;
    public Text purchaseText;
    public GameObject failureObj;


    public InventoryBehaviour playerInventory;

    public UpgradeCost[] costs;


    [SerializeField] [TextArea]private string costText;


    [SerializeField] GameObject[] modes;
    GameObject previousMode;

    public UpgradeController currentController;
    public UpgradeStorage storage;

    [SerializeField] PersistentData persistentData;

    [SerializeField] List<UpgradeView> upgradeViews = new List<UpgradeView>();
    private int currentUpgradeView = 0;

    [SerializeField] private Image viewImage;


    private void Start()
    {
        previousMode = modes[0];       
    }

    public void ApplyPurchase()
    {

        if (currentController != null && upgrade != null && ApplyCosts(costs))
        {
            Upgrade addedUpgrade = storage.AddUpgrade(upgrade);
            currentController.PlaceUpgrade(addedUpgrade);
            ClosePurchaseWindow();

        } else
        {
            //not enough resources
            failureObj.gameObject.SetActive(true);
        }

        currentController = null;


    }

    public void ApplyData()
    {
        if (upgrade != null)
        {
            purchaseText.text = costText;

            string ptext = costText;

            string[] _costElement = new string[costs.Length];
            for (int i = 0;i<costs.Length;i++)
            {
                _costElement[i] = costs[i].quantity + "x " + costs[i].name;

            }
           string _costText = string.Join(", ", _costElement);

            purchaseText.text = ptext.Replace("{upgrade}", upgrade.upgradeName).Replace("{cost}", _costText);

        }
    }

    public void EnterShopMode(int m)
    {
        modes[m].SetActive(true);
        previousMode.SetActive(false);

        previousMode = modes[m];

    }

    public void ClosePurchaseWindow()
    {
        purchaseWindow.SetActive(false);
        failureObj.gameObject.SetActive(false);
    }

    public void SwitchUpgradeView()
    {
        upgradeViews[currentUpgradeView].tab.SetActive(false);

        currentUpgradeView++;
        if (currentUpgradeView >= upgradeViews.Count)
        {
            currentUpgradeView = 0;
        }

        UpgradeView v = upgradeViews[currentUpgradeView];
        v.tab.SetActive(true);

        viewImage.sprite = v.sprite;

      //  currentController = v.upgradeController;

    }

    public bool ApplyCosts(UpgradeCost[] materials)      
    {

        Inventory invPlayer = playerInventory.inventory;


        int level = upgrade.level;


        bool enough = true;
        for (int i = 0;i<materials.Length;i++)
        {
            if (invPlayer.GetOreAmount(materials[i].name) < materials[i].quantity)
            {
                enough = false;
                break;
            }
        }


        int calculcatedBipCost = (int)(200 * Mathf.Pow(1.3f, level - 1));
        if (persistentData.bips < calculcatedBipCost) {
            enough = false;
        }

        if (enough)
        {
            for (int i = 0; i < materials.Length; i++)
            {
                invPlayer.RetrieveAmount(materials[i].name, materials[i].quantity);
            }

            persistentData.bips -= Random.Range(3, 5);

        }

        return enough;

    }

    [System.Serializable]
    public struct UpgradeView
    {
        public Sprite sprite;
        public GameObject tab;
        public UpgradeController upgradeController;
    }
}
