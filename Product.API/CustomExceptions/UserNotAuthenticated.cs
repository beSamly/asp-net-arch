using System;

public class UserNotAuthenticated : CustomException
{
    public UserNotAuthenticated(string message):base(message)
    {
    }
}