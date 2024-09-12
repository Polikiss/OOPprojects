namespace Itmo.ObjectOrientedProgramming.Lab3.User;

public record MessageStatus()
{
    public sealed record Read() : MessageStatus;

    public sealed record UnRead() : MessageStatus;
}