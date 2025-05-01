using System;
using TMPro;
using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;

public class CreateTestController : ControllerBase<Guid>
{
    [SerializeField] private GetClientController _getClientController;

    [SerializeField] private TMP_InputField _name;

    [SerializeField] private TMP_InputField _seconds;
    [SerializeField] private TMP_InputField _minutes;
    [SerializeField] private TMP_InputField _hours;

    [SerializeField] private Toggle _isPublished;
    [SerializeField] private Toggle _isTimeLimited;

    private UserDto _userData;

    public void CreateTest()
    {
        var userData = SavedUserData.Get();

        if (userData is null)
            return;

        _userData = userData;

        if (int.TryParse(_seconds.text, out int seconds) && int.TryParse(_minutes.text, out int minutes) && int.TryParse(_hours.text, out int hours))
        {
            var request = new CreateTestRequest()
            { 
                TestName = _name.text, 
                Seconds = seconds, 
                Minutes = minutes, 
                Hours = hours, 
                IsPublished = _isPublished.isOn, 
                IsTimeLimited = _isTimeLimited.isOn, 
                VerdictsList = new List<string>() { "s" }
            };

            Sender.PostData(request, $"clients/{_userData.ClientId}/test", OnHandleComplete, HttpMethods.Post, _userData.JwtToken);
        }
    }

    protected override void OnHandleComplete(string responseData)
    {
        base.OnHandleComplete(responseData);

        _getClientController.GetClient(_userData);
    }
}
