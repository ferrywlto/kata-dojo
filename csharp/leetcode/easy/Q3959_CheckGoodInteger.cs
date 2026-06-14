public class Q3959_CheckGoodInteger
{
    // TC: O(log n)
    // SC: O(1)
    public bool CheckGoodInteger(int n)
    {
        var num = n;
        var digitSum = 0;
        var squareSum = 0;
        while (num > 0)
        {
            var digit = num % 10;
            var square = digit * digit;
            digitSum += digit;
            squareSum += square;
            num /= 10;
        }

        return squareSum - digitSum >= 50;
    }

    public static TheoryData<int, bool> TestData => new()
    {
        { 1000, false },
        { 19, true },
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int input, bool expected)
    {
        var actual = CheckGoodInteger(input);
        Assert.Equal(expected, actual);
    }
}
