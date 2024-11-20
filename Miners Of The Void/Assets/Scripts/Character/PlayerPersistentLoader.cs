using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPersistentLoader : MonoBehaviour
{
    [SerializeField] PersistentData persistentData;
    [SerializeField] Health health;
    // Start is called before the first frame update
    void Start()
    {
        health.immortality = persistentData.immortality;
    }

}
