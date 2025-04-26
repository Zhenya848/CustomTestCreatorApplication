using TMPro;
using UnityEngine;
using System;

public class TaskUiModel : MonoBehaviour
{
    [SerializeField] private string _id;
    [SerializeField] private TextMeshProUGUI _number;

    public void Set(string id, int number)
    {
        if (number < 1)
            return;

        _number.text = number.ToString();
        _id = id;
    }

    public void DisplayInfo()
    {
        var taskInfoHandler = GameObject.Find("TaskInfoHandler").GetComponent<TaskInfoHandler>();

        if (Guid.TryParse(_id, out Guid id))
            taskInfoHandler.Handle(id);
    }
}
