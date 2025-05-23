using UnityEngine;

public class MyTestsHandler : MonoBehaviour
{
    [SerializeField] private GetClientController _getClientController;
    [SerializeField] private PageController _pageController;

    [SerializeField] private GameObject _testsPage;
    [SerializeField] private GameObject _registrationPage;

    [SerializeField] private TestContainer _testContainer;

    public void Handle()
    {
        if (_getClientController.Response is null || _getClientController.Response.Result is null)
        {
            _pageController.DisplayPage(_registrationPage);
            return;
        }

        _testContainer.AddTests(_getClientController.Response.Result.Tests);

        _pageController.DisplayPage(_testsPage);
    }
}
