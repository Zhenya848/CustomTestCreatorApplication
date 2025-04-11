using UnityEngine;
using TMPro;

public class LoginController : ControllerBase<UserDto>
{
    [SerializeField] private TMP_InputField Email;
    [SerializeField] private TMP_InputField Password;

    [SerializeField] private GetClientController _getClientController;

    public void Login()
    {
        var request = new LoginUserRequest() 
            { Email = Email.text, Password = Password.text };

        Sender.PostData(request, "account/login", OnHandleComplete);
    }

    protected override void OnHandleComplete(string responseData)
    {
        base.OnHandleComplete(responseData);

        _getClientController.GetClient(Response.Result);

        PlayerPrefs.SetString(Constants.Tags.USER_DATA_TAG, responseData);

        Debug.Log(Response);
    }
}
