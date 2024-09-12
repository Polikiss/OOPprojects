using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee;

public class AddresseeDecoratorFilter : IAddressee
{
    private readonly IAddressee _addressee;
    private readonly ImportanceLevel _filter;

    public AddresseeDecoratorFilter(IAddressee addressee, ImportanceLevel importanceLevel)
    {
        _addressee = addressee;
        _filter = importanceLevel;
    }

    public void DeliverMessage(Message message)
    {
        if (message.ImportanceLevel == _filter) _addressee.DeliverMessage(message);
    }
}