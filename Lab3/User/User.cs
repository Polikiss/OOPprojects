using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.User;

public class User
{
    private readonly List<MessageWithStatus> _messages;

    public User(string name)
    {
        Name = name;
        _messages = new List<MessageWithStatus>();
    }

    public string Name { get; }
    public IReadOnlyList<MessageWithStatus> Messages => _messages;

    public void GetMessage(Message message)
    {
        _messages.Add(new MessageWithStatus(message, new MessageStatus.UnRead()));
    }

    public MarkResult MarkMessageRead(Message message)
    {
        MarkResult markResult = new MarkResult.AlreadyRead();
        foreach (MessageWithStatus lookingMessage in _messages.ToList())
        {
            if (lookingMessage.Message != message || lookingMessage.Status is MessageStatus.Read) continue;
            var newMessage = new MessageWithStatus(lookingMessage.Message, new MessageStatus.Read());
            _messages.Remove(lookingMessage);
            _messages.Add(newMessage);
            markResult = new MarkResult.SuccessMark();
        }

        return markResult;
    }
}