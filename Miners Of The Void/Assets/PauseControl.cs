using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseControl : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject settingsPanel;

    public GameObject backMainMenuButton;
    // Start is called before the first frame update
    void Awake()
    {
               
    }
    
    public void OpenSettings()
    {
        settingsPanel.SetActive(true);
    }
}
