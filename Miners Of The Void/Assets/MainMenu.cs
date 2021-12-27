using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MainMenu : MonoBehaviour
{
    public GameObject loginScene;
    public GameObject registerScene;
    ServerMOV server;
    Button register;


    // Start is called before the first frame update
    private void Start()
    {
        server = gameObject.GetComponent<ServerMOV>();
    }


    public void ChangeScenes(bool res)
    {
        loginScene.SetActive(res);
        registerScene.SetActive(!res);
    }
    public void Register()
    {
        server.RegisterPlayer();
    }

}
