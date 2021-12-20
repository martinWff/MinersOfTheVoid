using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EntityManager : MonoBehaviour
{
    public bool movement = true;
    public bool weapon = true;
    public bool life = true;

    public CharacterMovement movementScript;
    public CharacterWeapon weaponScript;
    public HealthBar lifeScript;
    public SpriteRenderer spriteRenderer;

    private void Start()
    {
        if (gameObject.tag == "Spaceship" || gameObject.tag == "Player")
        {
            movementScript = gameObject.GetComponent<CharacterMovement>();
            weaponScript = gameObject.GetComponent<CharacterWeapon>();
            lifeScript = gameObject.GetComponent<HealthBar>();
            spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        }
    }
    public void disableEntity(bool disableRenderer)
    {
        movementScript.enabled = false;
        weaponScript.enabled = false;
        lifeScript.enabled = false;
        if (disableRenderer) spriteRenderer.enabled = false;
    }
    public void enableEntity(bool disableRenderer)
    {
        movementScript.enabled = true;
        weaponScript.enabled = true;
        lifeScript.enabled = true;
        if (disableRenderer) spriteRenderer.enabled = true;
    }
    public void animationRun(bool condition)
    {
        movementScript.animated = condition;
        weaponScript.firePermission = !condition;
    }
    public void SceneChanger(int id)
    {
        SceneManager.LoadScene(id);
    }
    
        
    
}
