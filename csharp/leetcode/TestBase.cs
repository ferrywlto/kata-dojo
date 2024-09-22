public abstract class TestBase
{
    protected readonly ITestOutputHelper Output;
    public TestBase(ITestOutputHelper output) 
    { 
        Output = output;
    }
}

public abstract class EnhancedTestBase : TestBase
{
    public abstract IEnumerable<object[]> TestData { get; }
    protected EnhancedTestBase(ITestOutputHelper output) : base(output)
    {
    }
}
