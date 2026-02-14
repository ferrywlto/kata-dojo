public class Q2520_CountDigitsThatDivideNumber
{
    // TC: O(log n), n scale with size of num, n shrink by factor of 10 per operation
    // SC: O(1), space used does not scale with input
    public int CountDigits(int num)
    {
        var current = num;
        var count = 0;
        while (current > 0)
        {
            var digit = current % 10;
            if (num % digit == 0) count++;
            current /= 10;
        }
        return count;
    }
    public static List<object[]> TestData =>
    [
        [7, 1],
        [121, 2],
        [1248, 4],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int input, int expected)
    {
        var actual = CountDigits(input);
        Assert.Equal(expected, actual);
    }
}
