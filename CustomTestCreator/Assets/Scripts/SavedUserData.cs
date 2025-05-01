using Newtonsoft.Json;
using UnityEngine;

public class SavedUserData : MonoBehaviour
{
    public static UserDto Get()
    {
        var userData = PlayerPrefs.GetString(Constants.Tags.USER_DATA_TAG);

        if (string.IsNullOrWhiteSpace(userData))
            return null;

        var response = JsonConvert.DeserializeObject<Envelope<UserDto>>(userData);

        if (response is null || response.ResponseErrors is not null)
            return null;

        return response.Result;
    }
}
