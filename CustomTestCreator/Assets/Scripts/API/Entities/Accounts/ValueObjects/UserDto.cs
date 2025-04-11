using System;

public record UserDto
{
    public string JwtToken { get; set; }
    public Guid ClientId { get; set; }
}
