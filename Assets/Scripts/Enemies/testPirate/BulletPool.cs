using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{

    public static BulletPool bulletPoolInstanse;

    [SerializeField]
    private GameObject pooledBullet;
    private bool notEnougthBulletsInPool = true;

    //list to store the bullets
    private List<GameObject> bullets;

    private void Awake()
    {
        
        bulletPoolInstanse = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        bullets = new List<GameObject>();
    }

    public GameObject GetBullet()
    {

        //if are bullets in the list
        if(bullets.Count > 0)
        {
            
            for(int i = 0; i < bullets.Count; i++)
            {
                if(!bullets[i].activeInHierarchy)
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

   
}
