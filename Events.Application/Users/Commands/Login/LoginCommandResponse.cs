﻿namespace Events.Application.Users.Commands.Login
{
    public class LoginCommandResponse
    {
        public string JwtToken { get; init; } = string.Empty;
        public string RefreshToken { get; init; } = string.Empty;
    }
}
