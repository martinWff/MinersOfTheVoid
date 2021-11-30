using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseControl : MonoBehaviour
{
    public GameObject pausePanel;
    public static PauseControl instance;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else if (instance != this)
        {
            Destroy(gameObject);
        }
       
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pausePanel.SetActive(!pausePanel.activeSelf);
        }
    }
}
