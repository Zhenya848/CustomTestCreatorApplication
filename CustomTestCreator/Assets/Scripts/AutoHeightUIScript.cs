using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AutoHeightUIScript : MonoBehaviour
{
    private TextMeshProUGUI _text;
    private RectTransform _content;

    private void Awake()
    {
        _content = GetComponent<RectTransform>();
        _text = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        if (_text != null && _content != null)
        {
            _content.sizeDelta = new Vector2(_content.sizeDelta.x, _text.preferredHeight);
        }
    }
}
