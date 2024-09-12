using System.Collections;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.ParseResults;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests;

public class CommandTest
{
    [Theory]
    [ClassData(typeof(TestData))]
    public void ParserShouldReturnCommand(string command)
    {
        // Arrange
        var parser = new Parser.Parser();

        // Act
        ParseResult result = parser.Pars(command);

        // Assert
        Assert.IsType<ParseResult.Success>(result);
    }

    private class TestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { "connect /Users -m local" };
            yield return new object[] { "file show -m console" };
            yield return new object[] { "file move /User/test.txt /User/Document" };
            yield return new object[] { "file rename /User/test.txt success" };
            yield return new object[] { "file copy /User/test.txt /User/Document" };
            yield return new object[] { "file delete /User/test.txt " };
            yield return new object[] { "disconnect" };
            yield return new object[] { "tree list -d 4" };
            yield return new object[] { "tree goto /User/Document" };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}