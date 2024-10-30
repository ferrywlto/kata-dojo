public class Q2283_CheckIfNumberHasEqualDigitCountAndDigitValue
{
    public bool DigitCount(string num)
    {
        return false;
    }
    public static List<object[]> TestData =>
    [
        ["1210", true],
        ["030", false],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, bool expected)
    {
        var actual = DigitCount(input);
        Assert.Equal(expected, actual);
    }
}