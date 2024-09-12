using Itmo.ObjectOrientedProgramming.Lab3.AddresseLogger;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee;

public class AddresseeDecoratorLogger : IAddressee
{
    private readonly IAddressee _addressee;
    private readonly IAddresseeLogger _logger;

    public AddresseeDecoratorLogger(IAddressee addressee, IAddresseeLogger logger)
    {
        _addressee = addressee;
        _logger = logger;
    }

    public void DeliverMessage(Message message)
    {
        _logger.Log(message.Show());
        _addressee.DeliverMessage(message);
    }
}