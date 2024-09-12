using System;
using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab3.DriverDisplay;

public class DriverDisplay : IDriverDisplay
{
    private Color _color;

    public DriverDisplay(Color color)
    {
        _color = color;
    }

    public void ClearOutput()
    {
        Console.Clear();
    }

    public void ChangeTextColor(string message)
    {
        Crayon.Output.Rgb(_color.R, _color.G, _color.B).Text(message);
    }
}