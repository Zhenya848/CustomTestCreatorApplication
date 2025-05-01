using UnityEngine;
using Newtonsoft.Json;
using System.Linq;
using System;

public abstract class ControllerBase<TResponse> : MonoBehaviour
{
    public Envelope<TResponse> Response { get; private set; }

    private APISender _sender;
    private ErrorAnimation _errorAnimation;

    protected APISender Sender
    {
        get
        {
            if (_sender is null)
                _sender = GameObject.Find("ApiSender").GetComponent<APISender>();

            return _sender;
        }
    }

    protected ErrorAnimation ErrorAnimation
    {
        get
        {
            if (_errorAnimation is null)
                _errorAnimation = GameObject.Find("Error").GetComponent<ErrorAnimation>();

            return _errorAnimation;
        }
    }

    protected virtual void OnHandleComplete(string responseData)
    {
        Response = JsonConvert.DeserializeObject<Envelope<TResponse>>(responseData);

        if (Response is null)
        {
            ErrorAnimation.Play("Что - то пошло не так при обработке ответа");

            throw new Exception("Something went wrong while parsing the response");
        }

        if (Response.ResponseErrors is not null)
        {
            ErrorAnimation.Play(string.Join(", ", Response.ResponseErrors.Select(m => m.Message)));

            throw new Exception(string.Join(", ", Response.ResponseErrors.Select(x => $"Code: {x.Code}, Message: {x.Message}")));
        }
    }
}