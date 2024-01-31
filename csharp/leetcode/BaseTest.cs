namespace dojo.leetcode;

public class BaseTest
{
    protected readonly ITestOutputHelper? Output;

    public BaseTest(ITestOutputHelper output) { Output = output; }
    
    public BaseTest() => Output = null;
}