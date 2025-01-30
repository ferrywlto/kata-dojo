public class Q3042_CountPrefixAndSuffixPairsI
{
    public int CountPrefixSuffixPairs(string[] words)
    {
        return 0;
    }
    public static TheoryData<string[], int> TestData => new()
    {
        {["a","aba","ababa","aa"], 4},
        {["pa","papa","ma","mama"], 2},
        {["abab","ab"], 0},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string[] input, int expected)
    {
        var actual = CountPrefixSuffixPairs(input);
        Assert.Equal(expected, actual);
    }
}