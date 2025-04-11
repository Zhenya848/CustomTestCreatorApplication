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
            throw new Exception("Тест с таким id не найден");

        _testName.text = test.TestName;
        _isPublished.text = "Опубликовано: " + (test.IsPublished ? "да" : "нет");

        _seconds.text = "Секунд: " + test.LimitTime.Seconds.ToString();
        _minutes.text = "Минут: " + test.LimitTime.Minutes.ToString();
        _hours.text = "Часов: " + test.LimitTime.Hours.ToString();

        _pageController.DisplayPage(_testPage);
    }
}
