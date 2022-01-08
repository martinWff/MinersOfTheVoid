using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinShop : MonoBehaviour
{
    public int skinID;
    public Sprite skin0;
    public Sprite skin1;
    public Sprite skin2;
    public Sprite skin3;
    private GameObject player;
    private GameObject human;
    private int idSkin;
    public Array<int> bought;
    void Start()
    {
        bought = new Array<int>(4);
        player = GameObject.FindGameObjectWithTag("Spaceship");
        human = GameObject.FindGameObjectWithTag("Player");
    }

    public void ChooseSkin(int id)
    {
        if (id == 0)
        {
            player.GetComponent<SpriteRenderer>().sprite = skin0;
            SavePlayerStats.currentSkin = skin0;
        }
        if(id == 1 && CheckSkinInv(id))
        {
            player.GetComponent<SpriteRenderer>().sprite = skin1;
            SavePlayerStats.currentSkin = skin1;
        }
        if (id == 2 && CheckSkinInv(id))
        {
            player.GetComponent<SpriteRenderer>().sprite = skin2;
            SavePlayerStats.currentSkin = skin2;
        }
        if (id == 3 && CheckSkinInv(id))
        {
            player.GetComponent<SpriteRenderer>().sprite = skin3;
            SavePlayerStats.currentSkin = skin3;
        }
    }
    public bool CheckSkinInv(int id)
    {
        if (bought.Contains(id)) return true;
        else if (SavePlayerStats.coins >= 40)
        {
            SavePlayerStats.coins -= 40;
            bought.InsertAtEnd(id);
            return true;
        }
        else
        {
            return false;
        }
    }
    public void CloseMenu()
    {
        Destroy(gameObject);
        human.GetComponent<CharacterMovement>().enabled = true;
        GameObject.Find("NPCSkin").GetComponent<NPCSkins>().menuIsOpen = false;
    }
}
