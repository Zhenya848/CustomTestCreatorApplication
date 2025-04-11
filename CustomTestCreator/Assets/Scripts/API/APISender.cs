using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using System.Text;
using System;
using Newtonsoft.Json;

public class APISender : MonoBehaviour
{
    public void GetData(string path, Action<string> onComplete, string jwtToken = null) 
        => StartCoroutine(Get(path, onComplete, jwtToken));

    public void PostData(IRequest requestData, string path, Action<string> onComplete, string jwtToken = null) 
        => StartCoroutine(Post(requestData, path, onComplete, jwtToken));

    private IEnumerator Get(string path, Action<string> onComplete, string jwtToken = null)
    {
        using (UnityWebRequest www = UnityWebRequest.Get(Constants.API.API_URL + path))
        {
            if (string.IsNullOrWhiteSpace(jwtToken) == false)
                www.SetRequestHeader("Authorization", "Bearer " + jwtToken);

            yield return www.SendWebRequest();

            onComplete?.Invoke(www.downloadHandler.text);
        }
    }

    private IEnumerator Post(IRequest requestData, string path, Action<string> onComplete, string jwtToken = null)
    {
        string json = JsonConvert.SerializeObject(requestData);
        byte[] jsonToSend = new UTF8Encoding().GetBytes(json);

        using (UnityWebRequest www = UnityWebRequest.Post(Constants.API.API_URL + path, json))
        {
            if (string.IsNullOrWhiteSpace(jwtToken) == false)
                www.SetRequestHeader("Authorization", "Bearer " + jwtToken);

            www.SetRequestHeader("Content-Type", "application/json");

            www.uploadHandler = new UploadHandlerRaw(jsonToSend);
            www.downloadHandler = new DownloadHandlerBuffer();

            yield return www.SendWebRequest();

            onComplete?.Invoke(www.downloadHandler.text);
        }
    }
}
