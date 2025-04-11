using TMPro;
using UnityEngine;
using Newtonsoft.Json;

public class RegistrationController : ControllerBase<UserDto>
{
    [SerializeField] private TMP_InputField Username;
    [SerializeField] private TMP_InputField Email;
    [SerializeField] private TMP_InputField Password;
    [SerializeField] private TMP_InputField ConfirmedPassword;

    [SerializeField] private GetClientController _getClientController;

    public void Register()
    {
        if (Password.text != ConfirmedPassword.text)
            return;

        var request = new RegisterUserRequest
        { Username = Username.text, Email = Email.text, Password = Password.text };

        Sender.PostData(request, "account/registration", OnHandleComplete);
    }

    protected override void OnHandleComplete(string responseData)
    {
        base.OnHandleComplete(responseData);

        _getClientController.GetClient(Response.Result);

        PlayerPrefs.SetString(Constants.Tags.USER_DATA_TAG, responseData);

        Debug.Log(Response);
    }
}
