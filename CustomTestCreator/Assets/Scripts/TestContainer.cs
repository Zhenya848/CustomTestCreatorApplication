using UnityEngine;
using System.Collections.Generic;
using System;
using System.Collections;
using System.Linq;

public class TestContainer : MonoBehaviour
{
    [SerializeField] private float _cellSizeY;
    [SerializeField] private float _spacing;

    [SerializeField] private TestUiModel _testPrefab;

    private void InitializeRect()
    {
        float height = transform.childCount * (_cellSizeY + _spacing);

        var rectTransform = GetComponent<RectTransform>();

        rectTransform.sizeDelta = new Vector2(rectTransform.rect.width, height);
        rectTransform.anchoredPosition = new Vector2(0, -2 * height);
    }

    private void Start() => InitializeRect();

    public void AddTests(IEnumerable<TestDto> tests)
    {
        foreach (var test in tests)
        {
            _testPrefab.Set(test.Id.ToString(), test.TestName);
            Instantiate(_testPrefab.gameObject, transform);
        }

        InitializeRect();
    }

    public void DeleteTests()
    {
        foreach (Transform child in transform)
            DestroyImmediate(child.gameObject);

        InitializeRect();
    }
}
