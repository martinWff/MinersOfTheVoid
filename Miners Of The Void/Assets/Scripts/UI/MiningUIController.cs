using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class MiningUIController : MonoBehaviour
{
    public Image bar;

    public Image oreImage;

    public MiningManager miningManager;

    // Update is called once per frame
    void Update()
    {
        if (miningManager.IsMining())
        {
            bar.fillAmount = miningManager.GetProgress();
        }
    }


    public void OnStartMining(Tile t)
    {
        gameObject.SetActive(true);

        OreResourceObject obj = OreManager.instance.GetOreResourceByTile(t);

        if (obj != null && obj.materialResourceObjects.Length > 0)
        {
            oreImage.sprite = obj.materialResourceObjects[0].sprite;
            oreImage.transform.parent.gameObject.SetActive(true);
        } else
        {
            oreImage.sprite = null;
            oreImage.transform.parent.gameObject.SetActive(false);
        }
    }

    public void OnStoppedMining()
    {
        gameObject.SetActive(false);
    }
}
