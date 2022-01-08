using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class SavedData
{
    public Dictionary<string,int> inventory;
    public Upgrade[] humanoidUpgrades = new Upgrade[4];
    public Upgrade[] spaceshipUpgrades = new Upgrade[4];

    public Vector3Serializable humanoidPosition;
    public Vector3Serializable spaceshipPosition;

    public float humanoidHealth;
    public float spaceshipHealth;

    public int bips;
    public int experience;
    public int level;

    public float currentHealth;

    public int currentSceneId;

    public Contract[] contracts;

    public Contract currentContract;

}
