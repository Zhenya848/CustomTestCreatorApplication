[System.Serializable]
public record LoginUserRequest : IRequest
{
    public string Email { get; set; }
    public string Password { get; set; }
}
