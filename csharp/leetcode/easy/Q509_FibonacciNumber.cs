class Q509_FibonacciNumber
{
    // TC: From O(n^2) with recursion to O(n) with dynamic programming
    // SC: O(n)
    public int Fib(int n)
    {
        if (n <= 1) return n;

        // The n + 1 because zero-based index
        int[] nums = new int[n + 1];
        nums[0] = 0;
        nums[1] = 1;

        for (var i = 2; i <= n; i++)
            nums[i] = nums[i - 2] + nums[i - 1];

        return nums[n];
    }
}

class Q509_FibonacciNumberTestData : TestData
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
