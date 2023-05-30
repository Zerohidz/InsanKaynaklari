using System;

public sealed class TestException : Exception
{
    public TestException(string message) : base(message)
    {
    }
}
