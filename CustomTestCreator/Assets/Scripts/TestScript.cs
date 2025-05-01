using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    [SerializeField] private APISender _apiSender;

    public void Handle()
    {
        Debug.Log("Sending data");
        _apiSender.GetData("u", OnComplete, HttpMethods.Get);
    }

    public void OnComplete(string data)
    {
        Debug.Log(data);
    }
}
