namespace LogicLayer.Extended;

public class CustomException(string message) : Exception
{
    private string ErrorMessage { get; } = message;
}
