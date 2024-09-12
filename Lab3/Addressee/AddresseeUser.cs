using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee;

public class AddresseeUser : IAddressee
{
    private User.User _user;

    public AddresseeUser(User.User user)
    {
        _user = user;
    }

    public void DeliverMessage(Message message)
    {
        _user.GetMessage(message);
    }
}