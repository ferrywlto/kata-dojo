public class Q2255_CountPrefixesOfGivenString
{
    public int CountPrefixes(string[] words, string s)
    {
        return 0;
    }
    public static List<object[]> TestData =>
    [
        [new string[] {"a","b","c","ab","bc","abc"}, "abc", 3],
        [new string[] {"a","a"}, "a", 3],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string[] input, string s, int expected)
    {
        var actual = CountPrefixes(input, s);
        Assert.Equal(expected, actual);
    }
}