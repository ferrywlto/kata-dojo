public abstract class TestSubject
{
    protected readonly ITestOutputHelper _output;
    public TestSubject(ITestOutputHelper output) { _output = output; }
}

