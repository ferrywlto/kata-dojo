
namespace dojo.leetcode;

public class Q509_FibonacciNumber
{
    public int Fib(int n)
    {
        return 0;
    }
}

public class Q509_FibonacciNumberTestData: TestData
{
    protected override List<object[]> Data => 
    [
        [2, 1],
        [3, 2],
        [4, 3],
    ];
}

public class Q509_FibonacciNumberTests
{
    [Theory]
    [ClassData(typeof(Q509_FibonacciNumberTestData))]
    public void OfficialTestCases(int input, int expected)
    {
        var sut = new Q509_FibonacciNumber();
        var actual = sut.Fib(input);
        Assert.Equal(expected, actual);
    }
}