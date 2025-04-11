using TMPro;
using UnityEngine;
using System.Collections;

public class ErrorAnimation : MonoBehaviour
{
    private Animator _errorMessageAnimator;
    [SerializeField] private TextMeshProUGUI _errorMessage;

    private void Start()
    {
        _errorMessageAnimator = GetComponent<Animator>();
    }

    public void Play(in string message)
    {
        _errorMessage.text = message;
        StartCoroutine(PlayCoroutine());
    }

    private IEnumerator PlayCoroutine()
    {
        _errorMessageAnimator.SetBool("IsActive", true);

        yield return new WaitForSeconds(5.3f);

        _errorMessageAnimator.SetBool("IsActive", false);
    }
}
