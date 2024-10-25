public class Q2243_CalculateDigitSumOfAString
{
    public string DigitSum(string s, int k)
    {
        return string.Empty;
    }
    public static List<object[]> TestData =>
    [
        ["11111222223", 3, "135"],
        ["00000000", 3, "000"],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, int k, string expected)
    {
        var actual = DigitSum(input, k);
        Assert.Equal(expected, actual);
    }
}