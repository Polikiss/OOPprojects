using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messenger;

public class Messenger : IMessenger
{
    private IList<string> _messages = new List<string>();
    private IMessengerDriver _messengerDriver;

    public Messenger(IMessengerDriver messengerDriver)
    {
        _messengerDriver = messengerDriver;
    }

    public void GetMessage(string message)
    {
        _messages.Add(message);
        _messengerDriver.Show(message);
    }
}