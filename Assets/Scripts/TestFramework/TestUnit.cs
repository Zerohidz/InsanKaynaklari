public abstract class TestUnit
{

    protected static void Equal<T>(T self, T other)
        where T : notnull
    {
        FailIf(!self.Equals(other), $"{self} was not equal to {other}");
    }

    protected static void Ensure(bool condition)
    {
        FailIf(!condition, "Expression could not be ensured");
    }

    private static void FailIf(bool condition, string message)
    {
        if (condition)
            throw new TestException(message);
    }
}
