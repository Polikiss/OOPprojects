using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messenger;

public class MessengerDriver : IMessengerDriver
{
    private string? _message;
    public void Show(string message)
    {
        _message = message;
        MarkMessenger();
        Console.WriteLine(message);
        Console.WriteLine("\nMessenger");
    }

    public void MarkMessenger()
    {
        _message += "... Messenger";
    }
}