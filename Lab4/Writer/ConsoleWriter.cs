using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Driver;

public class ConsoleWriter : IWriter
{
    public void Print(string output)
    {
        Console.WriteLine(output);
    }
}