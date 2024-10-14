public class Q2138_DivideStringIntoGroupsOfSizeK
{
    public string[] DivideString(string s, int k, char fill)
    {
        return [];
    }
    public static List<object[]> TestData =>
    [
        ["abcdefghi", 3, 'x', new string[] {"abc","def","ghi"}],
        ["abcdefghij", 3, 'x', new string[] {"abc","def","ghi","jxx"}],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, int k, char fill, string[] expected)
    {
        var actual = DivideString(input, k, fill);
        Assert.Equal(expected, actual);
    }
}