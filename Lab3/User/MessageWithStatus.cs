using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.User;

public record MessageWithStatus(Message Message, MessageStatus Status);