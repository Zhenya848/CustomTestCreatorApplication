using System;
using UnityEngine;
using System.Linq;
using TMPro;

public class TaskInfoHandler : MonoBehaviour
{
    [SerializeField] private GetClientController _getClientController;

    [SerializeField] private GameObject _taskPage;
    [SerializeField] private GameObject _defaultInfoOfTest;

    [SerializeField] private TextMeshProUGUI _taskName;
    [SerializeField] private TextMeshProUGUI _taskMessage;

    public void Handle(Guid id)
    {
        var task = _getClientController.Response.Result.Tests
            .SelectMany(t => t.Tasks)
            .FirstOrDefault(i => i.Id == id);

        if (task is null)
            throw new Exception("Тест с таким id не найден");

        _taskName.text = task.TaskName;
        _taskMessage.text = task.TaskMessage;

        _defaultInfoOfTest.SetActive(false);
        _taskPage.SetActive(true);
    }
}
