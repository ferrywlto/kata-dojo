public class Q2180_CountIntegersWithEvenDigitSum
{
    // TC: O(n log 10), n scale with num, then log 10 for each number
    // SC: O(1), space used does not scale with input
    public int CountEven(int num)
    {
        var result = 0;
        while (num > 0)
        {
            var sum = 0;
            var temp = num;
            while (temp > 0)
            {
                sum += temp % 10;
                temp /= 10;
            }
            if (sum % 2 == 0) result++;

            num--;
        }
        return result;
    }
    public static List<object[]> TestData =>
    [
        [4, 2],
        [30, 14],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int input, int expected)
    {
        var actual = CountEven(input);
        Assert.Equal(expected, actual);
    }
}