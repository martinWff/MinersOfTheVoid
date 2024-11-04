using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInitializer : MonoBehaviour
{
    GameObject spaceship;
    GameObject humanoid;

    [SerializeField] PersistentData persistentData;

    // Start is called before the first frame update
    void Awake()
    {
        SaveManager.saveStarted += OnSavingStats;
        SaveManager.saveLoaded += OnLoadStats;
        
    }


    void OnSavingStats(SavedData sv)
    {
        sv.bips = persistentData.bips;
        sv.experience = persistentData.xp;
        sv.level = persistentData.level;
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
        persistentData.bips = sv.bips;
        persistentData.xp = sv.experience;
        persistentData.level = sv.level;
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
