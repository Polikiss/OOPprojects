namespace Itmo.ObjectOrientedProgramming.Lab3.Messages;

public record Message(ImportanceLevel ImportanceLevel, string Title, string Body)
{
    public string Show()
    {
        return Title + '\n' + Body + '\n';
    }
}