using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Addressee;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Topic;

public class Topic : ITopic
{
    private IList<Message> _messages = new List<Message>();
    public Topic(string name, IAddressee addressee)
    {
        Name = name;
        Addressee = addressee;
    }

    public string Name { get; }
    public IAddressee Addressee { get; }
    public void SetMassage(Message message)
    {
        _messages.Add(message);
        SendMessage(message);
    }

    private void SendMessage(Message message)
    {
        Addressee.DeliverMessage(message);
    }
}