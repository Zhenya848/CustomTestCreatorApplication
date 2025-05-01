using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GetClientController : ControllerBase<ClientDto>
{
    [SerializeField] private PageController _pageController;
    [SerializeField] private GameObject _accountPage;

    [SerializeField] private TextMeshProUGUI _username;
    [SerializeField] private TextMeshProUGUI _iconUserName;

    [SerializeField] private Toggle _isInfiniteMode;
    [SerializeField] private Toggle _isRandomTasks;

    [SerializeField] private GameObject _accountButton;
    [SerializeField] private GameObject _loginButton;

    public void GetClient(UserDto userData)
    {
        Sender.GetData($"clients/{userData.ClientId}", OnHandleComplete, HttpMethods.Get, userData.JwtToken);
    }

    protected override void OnHandleComplete(string responseData)
    {
        base.OnHandleComplete(responseData);

        _pageController.DisplayPage(_accountPage);

        _username.text = Response.Result.Name;
        _iconUserName.text = Response.Result.Name;

        _isInfiniteMode.isOn = Response.Result.IsInfiniteMode;
        _isRandomTasks.isOn = Response.Result.IsRandomTasks;

        _accountButton.SetActive(true);
        _loginButton.SetActive(false);

        Debug.Log(Response.Result);
    }
}
