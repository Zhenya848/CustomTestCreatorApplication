using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoginHandler : MonoBehaviour
{
    [SerializeField] private GetClientController _getClientController;
    [SerializeField] private PageController _pageController;

    [SerializeField] private Toggle _isInfiniteMode;
    [SerializeField] private Toggle _isRandomTasks;

    [SerializeField] private GameObject _accountPage;
    [SerializeField] private TextMeshProUGUI _username;

    public void Handle()
    {
        if (_getClientController.Response is null || _getClientController.Response.ResponseErrors is not null)
            return;

        _username.text = _getClientController.Response.Result.Name;

        _isInfiniteMode.isOn = _getClientController.Response.Result.IsInfiniteMode;
        _isRandomTasks.isOn = _getClientController.Response.Result.IsRandomTasks;

        _pageController.DisplayPage(_accountPage);
    }
}
