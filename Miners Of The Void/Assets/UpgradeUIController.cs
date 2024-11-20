using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeUIController : MonoBehaviour
{
    public Upgrade upgrade;

    public GameObject purchaseWindow;
    public Text purchaseText;
    public GameObject failureObj;


    public InventoryBehaviour playerInventory;

    public UpgradeCost[] costs;
    public int bipCost;


    [SerializeField] [TextArea]private string costText;


    [SerializeField] GameObject[] modes;
    GameObject previousMode;

    public UpgradeController currentController;
    public UpgradeStorage storage;
    public UpgradeStorageUI storageUI;

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
            storageUI.ReloadStorage();
        }
        else
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

            string[] _costElement = new string[costs.Length+1];
            for (int i = 0;i<costs.Length;i++)
            {
                _costElement[i] = costs[i].quantity + "x " + costs[i].name;

            }
            _costElement[costs.Length] = bipCost + "x bips";


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

    private void ClosePurchaseWindow()
    {
        //purchaseWindow.SetActive(false);

        MenuManager.instance.DeactivateSubPanel();

    }

    public bool ApplyCosts(UpgradeCost[] materials)      
    {

        Inventory invPlayer = playerInventory.inventory;

        bool enough = true;
        for (int i = 0;i<materials.Length;i++)
        {
            if (invPlayer.GetOreAmount(materials[i].name) < materials[i].quantity)
            {
                enough = false;
                break;
            }
        }


        int calculcatedBipCost = bipCost;
        if (persistentData.bips < calculcatedBipCost) {
            enough = false;
        }

        if (enough)
        {
            for (int i = 0; i < materials.Length; i++)
            {
                invPlayer.RetrieveAmount(materials[i].name, materials[i].quantity);
            }

            persistentData.bips -= calculcatedBipCost;

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
