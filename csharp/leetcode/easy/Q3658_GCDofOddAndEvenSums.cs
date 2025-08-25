public class Q3658_GCDofOddAndEvenSums
{
    // Actually it just need to return n, as the different of sum is always n
    // TC: O(1)
    // SC: O(1)                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            
    public int GcdOfOddEvenSums(int n)
    {
        var oddSum = 0;
        var evenSum = 0;
        for (var i = 0; i < n; i++)
        {
            var odd = (2 * i) + 1;
            var even = 2 * (i + 1);

            oddSum += odd;
            evenSum += even;
        }
        return GCD(oddSum, evenSum);
    }

    private int GCD(int a, int b)
    {
        if (b == 0) return a;
        return GCD(b, a % b);
    }

    public static TheoryData<int, int> TestData => new()
    {
        {4, 4},
        {5, 5},
        {6, 6},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int input, int expected)
    {
        var actual = GcdOfOddEvenSums(input);
        Assert.Equal(expected, actual);
    }
}
