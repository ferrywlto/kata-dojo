public class Q3090_MaxLengthSubstringWithTwoOccurences
{
    public int MaximumLengthSubstring(string s)
    {
        return 0;
    }
    public static TheoryData<string, int> TestData => new()
    {
        {"bcbbbcba", 4},
        {"aaaa", 2},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, int expected)
    {
        var actual = MaximumLengthSubstring(input);
        Assert.Equal(expected, actual);
    }
}