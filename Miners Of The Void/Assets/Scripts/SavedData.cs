using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class SavedData
{
    public Dictionary<string,int> inventory;
    public Upgrade[] humanoidUpgrades = new Upgrade[4];
    public Upgrade[] spaceshipUpgrades = new Upgrade[4];

    public Vector2Serializable characterPosition;

    public int bips;

    public float currentHealth;

    public int currentSceneId;



}
