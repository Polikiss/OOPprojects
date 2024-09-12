using Itmo.ObjectOrientedProgramming.Lab3.DriverDisplay;

namespace Itmo.ObjectOrientedProgramming.Lab3.Display;

public class Display : IDisplay
{
    private readonly IDriverDisplay _driverDisplay;
    private string _message = "There is no new messages for you";

    public Display(IDriverDisplay driverDisplay)
    {
        _driverDisplay = driverDisplay;
    }

    public void SetMessage(string message)
    {
        _message = message;
        ShowMessage();
    }

    public void ShowMessage()
    {
        _driverDisplay.ChangeTextColor(_message);
    }
}