using System;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class UpdateClientController : ControllerBase<Guid>
{
    [SerializeField] private GetClientController _getClientController;

    [SerializeField] private TextMeshProUGUI _username;
    [SerializeField] private Toggle _isRandomTasks;
    [SerializeField] private Toggle _isInfiniteMode;

    private UserDto _userData;

    public void UpdateClient()
    {
        var userData = SavedUserData.Get();

        if (userData is null)
            return;

        _userData = userData;

        var request = new UpdateClientRequest()
        { IsInfiniteMode = _isInfiniteMode.isOn, IsRandomTasks = _isRandomTasks.isOn, Name = _username.text };

        var clientId = _userData.ClientId;
        var jwtToken = _userData.JwtToken;

        Sender.PostData(request, $"clients/{clientId}", OnHandleComplete, HttpMethods.Put, jwtToken);
    }

    protected override void OnHandleComplete(string responseData)
    {
        base.OnHandleComplete(responseData);

        _getClientController.GetClient(_userData);
    }
}
