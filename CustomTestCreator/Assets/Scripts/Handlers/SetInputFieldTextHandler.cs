using TMPro;
using UnityEngine;

public class SetInputFieldTextHandler : MonoBehaviour
{
    [SerializeField] private TMP_InputField _inputField;
    [SerializeField] private TextMeshProUGUI _textMeshPro;

    public void Handle() =>
        _textMeshPro.text = _inputField.text;
}
