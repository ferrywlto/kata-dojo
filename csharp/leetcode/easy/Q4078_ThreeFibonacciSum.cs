public class Q4078_ThreeFibonacciSum
{
    // TC: O(n)
    // SC: O(1)
    public bool ThreeFibonacciSum(int n)
    {
        Span<int> tmp = stackalloc int[3];
        tmp = [0, 1, 1];
        var sum = 2;

        if (n == sum) return true;
        // 0, 1, 1 => 2
        // 1, 1, 2 => 4, 2 - 0 + 2 = 4
        // 1, 2, 3 => 6, 4-1+3 = 6
        // 2, 3, 5 => 10, 6 - 1 + 5 = 10
        // 3, 5, 8 => 16, 10-2 + 8 = 16
        // 1. it must be even
        // 2. the 2n => n = a + b => 2a + 2b or a + b + (a + b), 2*fib(n)
        if (n % 2 != 0) return false;
        var half = n / 2;
        // Even one billion roughly takes 50 sums so it is still quick
        while (tmp[2] < n)
        {
            /* original approach
            sum -= tmp[0];
            var next = tmp[1] + tmp[2];
            sum += next;
            if (sum == n) return true;
            */
            // make use of the doubling observation
            var next = tmp[1] + tmp[2];
            if (next == half) return true;

            tmp[0] = tmp[1];
            tmp[1] = tmp[2];
            tmp[2] = next;
        }
        return false;
    }

    public static TheoryData<int, bool> TestData => new()
    {
        {16, true},
        {8, false},
        {2, true},
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int input, bool expected)
    {
        var actual = ThreeFibonacciSum(input);
        Assert.Equal(expected, actual);
    }
}
