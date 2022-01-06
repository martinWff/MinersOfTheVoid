using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChanger : MonoBehaviour
{

    public int id;
    public void OnClick()
    {
        SceneManager.LoadScene(id);
    }
}
