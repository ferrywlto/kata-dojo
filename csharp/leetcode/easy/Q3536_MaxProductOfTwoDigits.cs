public class Q3536_MaxProductOfTwoDigits
{
    // TC: O(n), n scale with number of digits in n
    // SC: O(1), space used does not scale with input
    public int MaxProduct(int n)
    {
        var digits = new int[2];
        while (n > 0)
        {
            var digit = n % 10;
            if (digit >= digits[0])
            {
                digits[1] = digits[0];
                digits[0] = digit;
            }
            else if (digit >= digits[1])
            {
                digits[1] = digit;
            }
            n /= 10;
        }
        return digits[0] * digits[1];
    }
    public static TheoryData<int, int> TestData => new()
    {
        {31, 3},
        {22, 4},
        {124, 8},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int input, int expected)
    {
        var actual = MaxProduct(input);
        Assert.Equal(expected, actual);
    }
}
