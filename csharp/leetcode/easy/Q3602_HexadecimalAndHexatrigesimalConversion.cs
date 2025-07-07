public class Q3602_HexadecimalAndHexatrigesimalConversion
{
    public string ConcatHex36(int n)
    {
        return "";
    }
    public static TheoryData<int, string> TestData => new()
    {
        {13, "A91P1"},
        {36, "5101000"},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int input, string expected)
    {
        var actual = ConcatHex36(input);
        Assert.Equal(expected, actual);
    }
}