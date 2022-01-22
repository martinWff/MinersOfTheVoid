using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoaderButton : MonoBehaviour
{
    public SceneChanger sceneChanger;
    // Start is called before the first frame update
    public void LoadGame()
    {
        if (SaveSystem.SaveExists(SaveManager.instance.key)) {
            SaveManager.instance.OnLoading();
        } else
        {
            sceneChanger.OnClick();
        }
    }
}
