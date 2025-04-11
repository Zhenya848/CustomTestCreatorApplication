using UnityEngine;
using TMPro;
using System;
using System.Linq;

public class TestInfoHandler : MonoBehaviour
{
    [SerializeField] private GetClientController _getClientController;

    [SerializeField] private PageController _pageController;
    [SerializeField] private GameObject _testPage;
    
    [SerializeField] private TextMeshProUGUI _testName;
    [SerializeField] private TextMeshProUGUI _isPublished;

    [SerializeField] private TextMeshProUGUI _seconds;
    [SerializeField] private TextMeshProUGUI _minutes;
    [SerializeField] private TextMeshProUGUI _hours;

    public void Handle(Guid testId)
    {
        var test = _getClientController.Response.Result.Tests
            .FirstOrDefault(i => i.Id == testId);

        if (test is null)
            throw new Exception("���� � ����� id �� ������");

        _testName.text = test.TestName;
        _isPublished.text = "������������: " + (test.IsPublished ? "��" : "���");

        _seconds.text = "������: " + test.LimitTime.Seconds.ToString();
        _minutes.text = "�����: " + test.LimitTime.Minutes.ToString();
        _hours.text = "�����: " + test.LimitTime.Hours.ToString();

        _pageController.DisplayPage(_testPage);
    }
}
