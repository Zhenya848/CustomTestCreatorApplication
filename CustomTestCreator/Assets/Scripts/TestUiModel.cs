using TMPro;
using UnityEngine;
using System;

public class TestUiModel : MonoBehaviour
{
    [SerializeField] private string _id;
    [SerializeField] private TextMeshProUGUI _testNameText;

    public void Set(string id, string testName)
    {
        _id = id;
        _testNameText.text = testName;
    }

    public void DisplayInfo()
    {
        var testInfoHandler = GameObject.Find("TestInfoHandler").GetComponent<TestInfoHandler>();

        if (Guid.TryParse(_id, out Guid id))
            testInfoHandler.Handle(id);
    }
}
