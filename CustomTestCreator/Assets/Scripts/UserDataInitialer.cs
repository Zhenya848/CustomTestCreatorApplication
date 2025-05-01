using UnityEngine;

public class UserDataInitialer : MonoBehaviour
{
    [SerializeField] private GetClientController _getClientController;

    private void Start()
    {
        var userData = SavedUserData.Get();

        if (userData is null)
            return;

        _getClientController.GetClient(userData);
    }
}
