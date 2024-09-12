using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee;

public class AddresseeGroup : IAddressee
{
    private IList<IAddressee> _addressees;

    public AddresseeGroup(IList<IAddressee> addressees)
    {
        _addressees = addressees;
    }

    public void DeliverMessage(Message message)
    {
        foreach (IAddressee addressee in _addressees)
        {
            addressee.DeliverMessage(message);
        }
    }
}