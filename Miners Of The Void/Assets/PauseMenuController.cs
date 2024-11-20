using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    public GameObject cheatsTab;
    public Button backMainMenuButton;
    public GameObject settingsTab;

    private void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResumeButton()
    {
        //gameObject.SetActive(false);

        MenuManager.instance.DeactivatePanel();
    }

    public void OpenCheatsButton()
    {
       // cheatsTab.SetActive(true);
        MenuManager.instance.ActivateSubPanel(cheatsTab);
    }

    public void OpenSettings()
    {
        MenuManager.instance.ActivateSubPanel(settingsTab);
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(1);
    }

    private void OnEnable()
    {
        Time.timeScale = 0;
    }

    private void OnDisable()
    {
        Time.timeScale = 1;
    }
}
