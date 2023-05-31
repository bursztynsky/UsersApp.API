namespace API.Exceptions;

public class RandomUsersApiException : Exception
{
    public RandomUsersApiException(string message) : base(message)
    {
    }
}