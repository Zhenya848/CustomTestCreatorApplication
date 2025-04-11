using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegisterUserRequest : IRequest
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}
