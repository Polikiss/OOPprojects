using Itmo.ObjectOrientedProgramming.Lab3.Addressee;
using Itmo.ObjectOrientedProgramming.Lab3.AddresseLogger;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Messenger;
using Itmo.ObjectOrientedProgramming.Lab3.User;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class MessageTests
{
    [Fact]
    public void Message_ShouldBeUnread_AfterDelivery()
    {
        // Arrange
        var user = new User.User("Nastya");
        var message = new Message(ImportanceLevel.Normal, "Hallowen", "Let's meet at 7");
        IAddresseeLogger logger = new AddresseeLogger();
        IAddressee addresseeUser = new AddresseeDecoratorLogger(new AddresseeUser(user), logger);

        // Act
        addresseeUser.DeliverMessage(message);

        // Assert
        Assert.True(user.Messages[0].Status is MessageStatus.UnRead);
    }

    [Fact]
    public void Message_ShouldMarkAsRead_AfterMarking()
    {
        // Arrange
        var user = new User.User("Nastya");
        var message = new Message(ImportanceLevel.Normal, "Party", "Let's meet at 7");
        IAddresseeLogger logger = new AddresseeLogger();
        IAddressee addresseeUser = new AddresseeDecoratorLogger(new AddresseeUser(user), logger);
        addresseeUser.DeliverMessage(message);

        // Act
        user.MarkMessageRead(message);

        // Assert
        Assert.True(user.Messages[0].Status is MessageStatus.Read);
    }

    [Fact]
    public void Message_ShouldNotMarkMessageAsRead_AfterAlreadyRead()
    {
        // Arrange
        var user = new User.User("Nastya");
        var message = new Message(ImportanceLevel.Normal, "Party", "Let's meet at 7");
        IAddresseeLogger logger = new AddresseeLogger();
        IAddressee addresseeUser = new AddresseeDecoratorLogger(new AddresseeUser(user), logger);
        addresseeUser.DeliverMessage(message);
        user.MarkMessageRead(message);

        // Act
        MarkResult markResult = user.MarkMessageRead(message);

        // Assert
        Assert.True(markResult is MarkResult.AlreadyRead);
    }

    [Fact]
    public void Addressee_Log_AfterDeliverMessage()
    {
        // Arrange
        var user = new User.User("Nastya");
        var message = new Message(ImportanceLevel.Normal, "Party", "Let's meet at 7");
        IAddresseeLogger logger = Substitute.For<IAddresseeLogger>();
        IAddressee addresseeUser = new AddresseeDecoratorLogger(new AddresseeUser(user), logger);

        // Act
        addresseeUser.DeliverMessage(message);

        // Assert
        logger.Received().Log(message.Show());
    }

    [Fact]
    public void Messenger_ShouldGetMessage_WhenAddresseeDeliver()
    {
        // Arrange
        var message = new Message(ImportanceLevel.Normal, "Party", "Let's meet at 7");
        MessengerDriver messengerDriver = Substitute.For<MessengerDriver>();
        var messenger = new Messenger.Messenger(messengerDriver);
        IAddresseeLogger logger = new AddresseeLogger();
        IAddressee addresseeMessenger = new AddresseeDecoratorLogger(new AddresseeMessenger(messenger), logger);

        // Act
        addresseeMessenger.DeliverMessage(message);

        // Assert
        messengerDriver.Received().MarkMessenger();
    }

    [Fact]
    public void Filter_ShouldNotEndMessage_WithWrongImportantLevel()
    {
        // Arrange
        var user = new User.User("Nastya");
        var message = new Message(ImportanceLevel.Normal, "Party", "Let's meet at 7");
        IAddresseeLogger logger = new AddresseeLogger();
        AddresseeUser addresseeUser = Substitute.For<AddresseeUser>(user);
        IAddressee addressee = new AddresseeDecoratorFilter(new AddresseeDecoratorLogger(addresseeUser, logger), ImportanceLevel.Critical);

        // Act
        addressee.DeliverMessage(message);

        // Assert
        addresseeUser.DidNotReceive().DeliverMessage(message);
    }
}