using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SaveManager : MonoBehaviour
{
    public static System.Action<SavedData> saveStarted;

    public static System.Action<SavedData> saveLoaded;

    public static System.Action<SavedData> onAfterLoaded;

    public string key;

    public static SaveManager instance;
    private SavedData saveData;


    public UnityEvent<SavedData> onSaved;
    public UnityEvent<SavedData> onLoaded;

    public void OnSaving()
    {

         SavedData generatedSavedData = new SavedData();
         saveStarted?.Invoke(generatedSavedData);
         onSaved?.Invoke(generatedSavedData);

        SaveSystem.Save(generatedSavedData, key);
    }

    public void OnLoading()
    {
        SavedData sv = SaveSystem.Load<SavedData>(key);
        SceneManager.LoadScene(sv.currentSceneId);

        onLoaded?.Invoke(sv);

        /* saveLoaded?.Invoke(sv);


         onAfterLoaded?.Invoke(sv);*/
        saveData = sv;
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnSaving();
        } 


        if (Input.GetKeyDown(KeyCode.L))
        {
            OnLoading();
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

            SaveSystem.path = System.IO.Path.Combine(Application.persistentDataPath,"saves");
            SceneManager.sceneLoaded += SceneManager_sceneLoaded;
        }

    }

    private void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        if (saveData != null)
        {
            saveLoaded?.Invoke(saveData);

            onAfterLoaded?.Invoke(saveData);
            saveData = null;
        }
    }
}
