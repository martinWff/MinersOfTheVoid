using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class ServerMOV : MonoBehaviour
{
    private string BaseAPI = "http://vmi732425.contaboserver.net:3434";
    private bool loginSuccess;
    private bool finished = false;
    private string output;
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
    IEnumerator PostRequest(string url, string jsondata,System.Action<string> function)
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
            function(webRequest.downloadHandler.text);
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        
        //UpdatePlayerInfo scoreinfo = new UpdatePlayerInfo(3, 6);
        //string json2 = JsonUtility.ToJson(scoreinfo);
        //StartCoroutine(PostRequest(BaseAPI + "/player/updatescore", json2));
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
        Debug.Log(log.id);
        StartCoroutine(GetPlayersRequest(BaseAPI + "/player/getcoins/" + log.id, GetCoins));
    }

    public void GetCoins(string json)
    {
        PlayerCoins log = JsonUtility.FromJson<PlayerCoins>(json);
        SavePlayerStats.coins = log.coin;
        Debug.Log(SavePlayerStats.coins);
    }
}

public class LoginData
{
    public int id;
}
