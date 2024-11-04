using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUIController : MonoBehaviour
{
    public Health health;

    public Image healthBar;
    public Image shieldBar;

    // Update is called once per frame
    void Update()
    {
        if (health != null)
        {
            shieldBar.fillAmount = health.shield / health.maxShield.value;
            healthBar.fillAmount = health.hp / health.maxHP.value;
        }
    }
}
