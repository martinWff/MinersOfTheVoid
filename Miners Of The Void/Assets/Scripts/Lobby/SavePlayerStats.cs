using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SavePlayerStats 
{
    //Spaceship
    public static float playerDamage = 10;
    public static float totalShield = 10;
    public static float shield = 10;
    public static float hp = 20;
    public static float totalhp = 20;
    public static float moveForce = 8;
    public static float bulletSpeed = 18;
    public static bool backWeapon = false;
    public static bool backWeaponAquired = false;
    public static float speedLevel = 0;
    public static float dmgLevel = 0;
    public static float shieldLevel = 0;
    public static float healthLevel = 0;

    //HumanPlayer
    public static float playerDamageH = 10;
    public static float totalShieldH = 10;
    public static float shieldH = 10;
    public static float hpH = 20;
    public static float totalhpH = 20;
    public static float moveForceH = 4;
    public static float bulletSpeedH = 14;
    public static bool backWeaponH = false;
    public static float speedLevelH = 0;
    public static float dmgLevelH = 0;
    public static float shieldLevelH = 0;
    public static float healthLevelH = 0;

    //cheats
    public static bool immortality = false;
<<<<<<< Updated upstream
=======
    public static int exp = 0;
    public static int expNeeded = 200;
    public static int WorldLevel = 1;

    //level
    public static Hashtable humanLevels = new Hashtable(400);
>>>>>>> Stashed changes


    //Money
    public static int bips = 
        0;
}
