public class Q3622_CheckDivisibilityByDigitSumAndProduct
{
    // TC: O(d), where d is the number of digits in n.
    // SC: O(1), since we are using a constant amount of space.
    public bool CheckDivisibility(int n)
    {
        var original = n;
        var firstDigit = n % 10;
        var sum = firstDigit;
        var product = firstDigit;
        n /= 10;
        while (n > 0)
        {
            var digit = n % 10;
            sum += digit;
            product *= digit;
            n /= 10;
        }
        return original % (sum + product) == 0;
    }
    public static TheoryData<int, bool> TestData => new()
    {
        { 99, true},
        { 23, false},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int n, bool expected)
    {
        var actual = CheckDivisibility(n);
        Assert.Equal(expected, actual);
    }
}