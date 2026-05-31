public class Q3945_DigitFrequencyScore
{
    // TC: O(log n)
    // SC: O(1)
    public int DigitFrequencyScore(int n)
    {
        Span<int> freq = stackalloc int[10];
        while (n > 0)
        {
            freq[n % 10]++;
            n /= 10;
        }

        var result = 0;
        for (var i = 1; i < 10; i++)
        {
            result += i * freq[i];
        }
        return result;
    }

    public static TheoryData<int, int> TestData => new()
    {
        { 122, 5 },
        { 101, 2 },
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int input, int expected)
    {
        var actual = DigitFrequencyScore(input);
        Assert.Equal(expected, actual);
    }
}
