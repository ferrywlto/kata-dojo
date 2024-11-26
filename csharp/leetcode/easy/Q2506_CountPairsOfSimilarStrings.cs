public class Q2506_CountPairsOfSimilarStrings
{
    public int SimilarPairs(string[] words)
    {
        return 0;
    }
    public static List<object[]> TestData =>
    [
        [new string[] {"aba","aabb","abcd","bac","aabc"}, 2],
        [new string[] {"aabb","ab","ba"}, 3],
        [new string[] {"nba","cba","dba"}, 0],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string[] input, int expected)
    {
        var actual = SimilarPairs(input);
        Assert.Equal(expected, actual);
    }
}