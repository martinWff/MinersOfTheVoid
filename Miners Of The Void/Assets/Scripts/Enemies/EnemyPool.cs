using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    public static EnemyPool bulletInstanse;


    [SerializeField]
    private GameObject pooledBullet;
    private bool notEnougthBulletsInPool = true;

    // the list of bulets
    private List<GameObject> bullets;

    private void Awake()
    {
        bulletInstanse = this;
    }

    
    void Start()
    {
        bullets = new List<GameObject>();
    }


    public GameObject GetEnemyBullet()
    {
        //if are bullets in the list
        if (bullets.Count > 0)
        {

            for (int i = 0; i < bullets.Count; i++)
            {
                if (!bullets[i].activeInHierarchy)
                {
                    return bullets[i];
                }
            }

        }

        //if there is no bullets in the list 
        if (notEnougthBulletsInPool)
        {

            //adding another bullet in the List
            GameObject bul = Instantiate(pooledBullet);
            bul.SetActive(false);
            bullets.Add(bul);
            return bul;
        }


        return null;
    }

    //return the bullet when colid with player
    public void ReturnBullet(GameObject bullet)
    {
        bullet.SetActive(false);
    }
}
