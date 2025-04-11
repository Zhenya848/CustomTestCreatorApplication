using Newtonsoft.Json;
using UnityEngine;

public class UserDataInitialer : MonoBehaviour
{
    [SerializeField] private GetClientController _getClientController;

    private void Start()
    {
        var userData = PlayerPrefs.GetString(Constants.Tags.USER_DATA_TAG);

        if (string.IsNullOrWhiteSpace(userData))
            return;

        var response = JsonConvert.DeserializeObject<Envelope<UserDto>>(userData);

        if (response is null || response.ResponseErrors is not null)
            return;

        _getClientController.GetClient(response.Result);
    }
}
