using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class ServerMOV : MonoBehaviour
{
    private string BaseAPI = "http://vmi732425.contaboserver.net:3434";

    [System.Serializable]
    public class PlayerInfo
    {
        public string username;
        public int score;
        public PlayerInfo(string user, int s)
        {
            username = user;
            score = s;
        }
    }
    [System.Serializable]
    public class PlayerList
    {
        public PlayerInfo[] players;
    }
    [System.Serializable]
    public class RegisterPlayerInfo
    {
        public string username;
        public string password;
        public RegisterPlayerInfo(string u, string p)
        {
            username = u;
            password = p;
        }
    }
    [System.Serializable]
    public class UpdatePlayerInfo
    {
        public int id;
        public int score;
        public UpdatePlayerInfo(int i, int s)
        {
            id = i;
            score = s;
        }
    }
    IEnumerator GetPlayersRequest(string url)
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
        }
        Debug.Log(webRequest.downloadHandler.text);

        PlayerList playerList = JsonUtility.FromJson<PlayerList>(webRequest.downloadHandler.text);

        foreach (PlayerInfo player in playerList.players)
        {
            Debug.Log(player.username);
            Debug.Log(player.score);
        }
    }
    IEnumerator PostRequest(string url, string jsondata)
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
        }
    }
    // Start is called before the first frame update
    void Start()
    {
       /* RegisterPlayerInfo info = new RegisterPlayerInfo("nelio", "god");
        string json = JsonUtility.ToJson(info);
        Debug.Log(json);
        //StartCoroutine(GetPlayersRequest(BaseAPI + "/player/list"));
        //StartCoroutine(PostRequest(BaseAPI + "/player/new", json));
        UpdatePlayerInfo scoreinfo = new UpdatePlayerInfo(3, 666);
        string json2 = JsonUtility.ToJson(scoreinfo);
        StartCoroutine(PostRequest(BaseAPI + "/player/updatescore", json2));*/
    }

    public void RegisterPlayer()
    {
        RegisterPlayerInfo info = new RegisterPlayerInfo("nelio", "god");
        string json = JsonUtility.ToJson(info);
        Debug.Log(json);
        //StartCoroutine(GetPlayersRequest(BaseAPI + "/player/list"));
        //StartCoroutine(PostRequest(BaseAPI + "/player/new", json));
        UpdatePlayerInfo scoreinfo = new UpdatePlayerInfo(3, 666);
        string json2 = JsonUtility.ToJson(scoreinfo);
        StartCoroutine(PostRequest(BaseAPI + "/player/updatescore", json2));
    }

}
