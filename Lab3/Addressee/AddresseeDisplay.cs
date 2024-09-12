using Itmo.ObjectOrientedProgramming.Lab3.Display;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee;

public class AddresseeDisplay : IAddressee
{
    private IDisplay _display;

    public AddresseeDisplay(IDisplay display)
    {
        _display = display;
    }

    public void DeliverMessage(Message message)
    {
        _display.SetMessage(message.Show());
    }
}