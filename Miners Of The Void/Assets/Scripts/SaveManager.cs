using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static System.Action<SavedData> saveStarted;

    public static System.Action<SavedData> saveLoaded;

    public string key;


    public void OnSaving()
    {

         SavedData generatedSavedData = new SavedData();
         saveStarted?.Invoke(generatedSavedData);

        SaveSystem.Save(generatedSavedData, key);
    }

    public void OnLoading()
    {
        SavedData sv = SaveSystem.Load<SavedData>(key);
        saveLoaded?.Invoke(sv);
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
        SaveSystem.path = Application.dataPath + "/saves/";
    }

}
