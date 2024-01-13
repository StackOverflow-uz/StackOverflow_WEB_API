namespace LogicLayer.Extended;

public class StackException(string Message) : Exception
{
    public string ErrorMessage { get; } = Message;
}
