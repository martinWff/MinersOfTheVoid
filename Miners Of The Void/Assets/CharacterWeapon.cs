using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterWeapon : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletOffset = 1.5f;
    public float bulletSpeed = 18;
    public float bulletCooldownTime = 0.5f;
    private float bulletShootTime = 0.5f;
    public bool backweaponMode = false;
    public bool firePermission = false;
    public CharacterStat dmg = new CharacterStat(10);
    // Start is called before the first frame update

    private void Start()
    {
        Debug.Log(bulletPrefab);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject beautifulEnemiesThatWontDieAndWeWantToTestThisGame in enemies)
            {
                Destroy(beautifulEnemiesThatWontDieAndWeWantToTestThisGame);
            }
        }
        float fireInput = Input.GetAxis("Fire1");
        if (fireInput > 0 && (bulletShootTime <= 0) && firePermission)
        {
            Vector3 Shotdirection = transform.right;
            GameObject bullet = Instantiate(bulletPrefab, transform.position + (Shotdirection.normalized * bulletOffset), Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().velocity = Shotdirection.normalized * bulletSpeed;

            if (backweaponMode)
            {
                Vector3 Shotdirection2 = -transform.right;
                GameObject bullet2 = Instantiate(bulletPrefab, transform.position + (Shotdirection2.normalized * bulletOffset), Quaternion.identity);
                bullet2.GetComponent<Rigidbody2D>().velocity = Shotdirection2.normalized * bulletSpeed;
            }
            bulletShootTime = bulletCooldownTime;
        }
        if (bulletShootTime >= 0)
        {
            bulletShootTime -= Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.M)) Debug.Log(dmg.value+ " on game object "+gameObject.name);
        

        
    }
}
