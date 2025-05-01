using UnityEngine.UI;
using UnityEngine;

public class ToggleHandler : MonoBehaviour
{
    [SerializeField] private Toggle _isInfiniteMode;
    [SerializeField] private Toggle _isRandomTasks;

    private void Start()
    {
        _isInfiniteMode.onValueChanged.AddListener(OnInfiniteModeChanged);
        _isRandomTasks.onValueChanged.AddListener(OnRandomTasksChanged);
    }

    private void OnInfiniteModeChanged(bool value)
    {
        if (value)
            _isRandomTasks.isOn = true;
    }

    private void OnRandomTasksChanged(bool value)
    {
        if (_isInfiniteMode.isOn && value == false)
            _isInfiniteMode.isOn = false;
    }
}
