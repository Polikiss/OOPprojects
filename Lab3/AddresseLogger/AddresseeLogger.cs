using System;
using System.Globalization;

namespace Itmo.ObjectOrientedProgramming.Lab3.AddresseLogger;

public class AddresseeLogger : IAddresseeLogger
{
    public void Log(string message)
    {
        string time = default(DateTime).ToString(CultureInfo.InvariantCulture);
        Console.WriteLine(time);
    }
}