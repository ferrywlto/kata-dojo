public class Q2264_LargestThreeSameDigitNumberInString
{
    public string LargestGoodInteger(string num)
    {
        return string.Empty;
    }
    public static List<object[]> TestData =>
    [
        ["6777133339", "777"],
        ["2300019", "000"],
        ["42352338", ""],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, string expected)
    {
        var actual = LargestGoodInteger(input);
        Assert.Equal(expected, actual);
    }
}