public abstract class TestSubject
{
    protected readonly ITestOutputHelper Output;
    public TestSubject(ITestOutputHelper output) { Output = output; }
}

