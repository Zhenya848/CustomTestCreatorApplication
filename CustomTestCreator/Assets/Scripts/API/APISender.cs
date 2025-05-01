using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using System.Text;
using System;
using Newtonsoft.Json;
using System.Net.Http;

public class APISender : MonoBehaviour
{
    public void GetData(string path, Action<string> onComplete, HttpMethods httpMethod, string jwtToken = null) 
        => StartCoroutine(Get(path, onComplete, httpMethod, jwtToken));

    public void PostData(IRequest requestData, string path, Action<string> onComplete, HttpMethods httpMethod, string jwtToken = null) 
        => StartCoroutine(Post(requestData, path, onComplete, httpMethod, jwtToken));

    private IEnumerator Get(string path, Action<string> onComplete, HttpMethods httpMethod, string jwtToken = null)
    {
        var request = httpMethod switch
        {
            HttpMethods.Get => UnityWebRequest.Get(Constants.API.API_URL + path),
            HttpMethods.Delete => UnityWebRequest.Delete(Constants.API.API_URL + path),
            _ => UnityWebRequest.Get(Constants.API.API_URL + path)
        };

        using (UnityWebRequest www = request)
        {
            if (string.IsNullOrWhiteSpace(jwtToken) == false)
                www.SetRequestHeader("Authorization", "Bearer " + jwtToken);

            Debug.Log("Start sending " + www.url);

            yield return www.SendWebRequest();

            onComplete?.Invoke(www.downloadHandler.text);
        }
    }

    private IEnumerator Post(IRequest requestData, string path, Action<string> onComplete, HttpMethods httpMethod, string jwtToken = null)
    {
        string json = JsonConvert.SerializeObject(requestData);
        byte[] jsonToSend = new UTF8Encoding().GetBytes(json);

        var request = httpMethod switch
        {
            HttpMethods.Post => UnityWebRequest.Post(Constants.API.API_URL + path, json),
            HttpMethods.Put => UnityWebRequest.Put(Constants.API.API_URL + path, json),
            _ => UnityWebRequest.Post(Constants.API.API_URL + path, json)
        };

        using (UnityWebRequest www = request)
        {
            if (string.IsNullOrWhiteSpace(jwtToken) == false)
                www.SetRequestHeader("Authorization", "Bearer " + jwtToken);

            Debug.Log("Start sending " + www.url);

            www.SetRequestHeader("Content-Type", "application/json");

            www.uploadHandler = new UploadHandlerRaw(jsonToSend);
            www.downloadHandler = new DownloadHandlerBuffer();

            yield return www.SendWebRequest();

            onComplete?.Invoke(www.downloadHandler.text);
        }
    }
}
