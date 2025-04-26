using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

public class TaskContainer : MonoBehaviour
{
    [SerializeField] private float _cellSizeY;
    [SerializeField] private float _spacing;

    [SerializeField] private TaskUiModel _taskUiModel;

    private void InitializeRect()
    {
        int koef = transform.childCount % 5 == 0
            ? transform.childCount / 5
            : transform.childCount / 5 + 1;

        float height = koef * (_cellSizeY + _spacing);

        var rectTransform = GetComponent<RectTransform>();

        rectTransform.sizeDelta = new Vector2(rectTransform.rect.width, height);
        rectTransform.anchoredPosition = new Vector2(0, -2 * height);
    }

    private void Start() => InitializeRect();

    public void AddTasks(IEnumerable<TaskDto> tasks)
    {
        while (transform.childCount > 1)
            DestroyImmediate(transform.GetChild(1).gameObject);

        for (int i = 0; i < tasks.Count(); i++)
        {
            _taskUiModel.Set(tasks.ElementAt(i).Id.ToString(), i + 1);
            Instantiate(_taskUiModel.gameObject, transform);
        }

        InitializeRect();
    }
}
