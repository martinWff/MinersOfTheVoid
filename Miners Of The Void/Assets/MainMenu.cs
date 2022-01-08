using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public GameObject loginScene;
    public GameObject registerScene;
    public InputField username;
    public InputField password;
    public InputField email;
    public InputField loginUsername;
    public InputField loginPassword;
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
        server.Register(username.text, password.text, email.text);
    }
    public void Login()
    {
        server.Login(loginUsername.text, loginPassword.text);
        
      
    }

}
