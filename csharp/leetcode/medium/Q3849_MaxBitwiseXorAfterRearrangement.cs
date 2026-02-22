public class Q3849_MaxBitwiseXorAfterRearrangement
{
    public string MaximumXor(string s, string t)
    {
        return "";
    }
    public static TheoryData<string, string, string> TestData => new()
    {
        {"101", "011", "110"},
        {"0110", "1110", "1101"},
        {"0101", "1001", "1111"},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string s, string t, string expected)
    {
        var actual = MaximumXor(s, t);
        Assert.Equal(expected, actual);
    }
}
