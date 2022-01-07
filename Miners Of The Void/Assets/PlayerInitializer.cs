using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInitializer : MonoBehaviour
{
    GameObject spaceship;
    GameObject humanoid;
    // Start is called before the first frame update
    void Awake()
    {
        SaveManager.saveStarted += OnSavingStats;
        SaveManager.saveLoaded += OnLoadStats;
        
    }


    void OnSavingStats(SavedData sv)
    {
        sv.bips = SavePlayerStats.bips;
        sv.experience = SavePlayerStats.rp;
        sv.level = SavePlayerStats.level;
        sv.currentSceneId = SceneManager.GetActiveScene().buildIndex;
        if (humanoid == null || spaceship == null)
        {
            humanoid = GameObject.FindGameObjectWithTag("Player");
            spaceship = GameObject.FindGameObjectWithTag("Spaceship");
        }

        if (humanoid != null)
        {
            sv.humanoidPosition = humanoid.transform.position;
        }
        if (spaceship != null)
        {
            sv.spaceshipPosition = spaceship.transform.position;
        }
    }

    void OnLoadStats(SavedData sv)
    {
        SavePlayerStats.bips = sv.bips;
        SavePlayerStats.rp = sv.experience;
        SavePlayerStats.level = sv.level;
        if (humanoid == null || spaceship == null)
        {
            humanoid = GameObject.FindGameObjectWithTag("Player");
            spaceship = GameObject.FindGameObjectWithTag("Spaceship");
        }
        if (humanoid != null)
        {
            humanoid.transform.position = sv.humanoidPosition;
        }
        if (spaceship != null)
        {
            spaceship.transform.position = sv.spaceshipPosition;
        }

    }


}
