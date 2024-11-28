using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ServerMOV : MonoBehaviour
{
    [SerializeField] string BaseAPI;

    public Text error;
    [System.Serializable]
    public class PlayerInfo
    {
        public string username;
        public string password;
        public string email;
        public int id;
        public PlayerInfo(string user, string pass, string mail)
        {
            username = user;
            password = pass;
            email = mail;
        }
        public PlayerInfo()
        {
          
        }
    }
    [System.Serializable]
    public class PlayerList
    {
        public PlayerInfo[] accounts;
    }
    [System.Serializable]
    public class RegisterPlayerInfo
    {
        public string username;
        public string password;
        public string email;
        public RegisterPlayerInfo(string u, string p, string e)
        {
            username = u;
            password = p;
            email = e;
        }
    }
    [System.Serializable]
    public class UpdatePlayerInfo
    {
        public int id;
        public string email;
        public UpdatePlayerInfo(int i, string e)
        {
            id = i;
            email = e;
        }
    }
    IEnumerator GetPlayersRequest(string url, System.Action<string> function)
    {
        //Debug.Log(url);
        UnityWebRequest webRequest = UnityWebRequest.Get(url);
        yield return webRequest.SendWebRequest();
        if (webRequest.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.Log("Request Error!!");
        }
        else
        {
            Debug.Log(webRequest.downloadHandler.text);
            function(webRequest.downloadHandler.text);
        }
        Debug.Log(webRequest.downloadHandler.text);

        PlayerList playerList = JsonUtility.FromJson<PlayerList>( webRequest.downloadHandler.text);

        /*foreach (PlayerInfo player in playerList.accounts)
        {
            Debug.Log(player.username);
            

        }
        finished = true;*/
    }
    IEnumerator PostRequest(string url, string jsondata,System.Action<string> callback)
    {
        UnityWebRequest webRequest = new UnityWebRequest(url, "POST");
        byte[] jsonConverted = new System.Text.UTF8Encoding().GetBytes(jsondata);
        webRequest.uploadHandler = new UploadHandlerRaw(jsonConverted);
        webRequest.downloadHandler = new DownloadHandlerBuffer();
        webRequest.SetRequestHeader("Content-Type", "application/json");
        yield return webRequest.SendWebRequest();
        if (webRequest.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.Log("Request Error!!");
        }
        else
        {
            Debug.Log(webRequest.downloadHandler.text);
            if(callback !=null)
            callback(webRequest.downloadHandler.text);
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        string url = Application.persistentDataPath;
        string fileUrl = System.IO.Path.Combine(url, "server_settings.txt");
        if (System.IO.File.Exists(fileUrl))
        {
           string[] properties = System.IO.File.ReadAllLines(fileUrl);
           
            for (int i = 0;i<properties.Length;i++)
            {
                ParseProperty(properties[i], out string key, out string value);
                if (key == "url" && !string.IsNullOrEmpty(value))
                {
                    BaseAPI = value;
                }
            }

        } else
        {
            System.IO.StreamWriter stream = System.IO.File.CreateText(fileUrl);
            stream.WriteLine("url=");
            stream.Close();
            stream.Dispose();
        }
        
        //UpdatePlayerInfo scoreinfo = new UpdatePlayerInfo(3, 6);
        //string json2 = JsonUtility.ToJson(scoreinfo);
        //StartCoroutine(PostRequest(BaseAPI + "/player/updatescore", json2));
    }

    private bool ParseProperty(string text,out string key,out string value)
    {
        key = null;
        value = null;
        string[] kvp = text.Split("=", 2);
        for (int i = 0;i<kvp.Length;i++)
        {
            kvp[i] = kvp[i].Trim();
        }

        if (kvp.Length > 0)
        {
            if (!string.IsNullOrEmpty(kvp[0]))
            {
                key = kvp[0];
            } 

            if (kvp.Length == 2 && !string.IsNullOrEmpty(kvp[1]))
            {
                value = kvp[1];
            }
            return true;
        }

        return false;
    }

    // Update is called once per frame
    public void Register(string user, string password, string email)
    {
        RegisterPlayerInfo info = new RegisterPlayerInfo(user, password, email);
        string json = JsonUtility.ToJson(info);
        Debug.Log(json);
        
        StartCoroutine(PostRequest(BaseAPI + "/player/new", json,null));
    }
    public void Login(string user, string password)
    {
        string email ="";
        RegisterPlayerInfo info = new RegisterPlayerInfo(user, password,email);
        string json = JsonUtility.ToJson(info);
        StartCoroutine(PostRequest(BaseAPI + "/player/login",json, GetId));
    }
    public void GetId(string json)
    {
        LoginData log = JsonUtility.FromJson<LoginData>(json);
        if (json == string.Empty) error.text = "Error, wrong login data or server problems";
        Debug.Log(log.id);
        SavePlayerStats.id = log.id;
        StartCoroutine(GetPlayersRequest(BaseAPI + "/player/getcoins/" + log.id, GetCoins));
    }

    public void GetCoins(string json)
    {
        PlayerCoins log = JsonUtility.FromJson<PlayerCoins>(json);
        SavePlayerStats.coins = log.coin;
        Debug.Log(SavePlayerStats.coins);
        SceneManager.LoadScene(2);
        Debug.Log("load scene");
    }
}

public class LoginData
{
    public int id;
}
