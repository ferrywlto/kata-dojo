public class Q2506_CountPairsOfSimilarStrings
{
    // TC: O(n^2)
    // SC: O(n * m), n scale with length of words and m scale with unique characters in each word
    public int SimilarPairs(string[] words)
    {
        var result = 0;
        for (var i = 0; i < words.Length - 1; i++)
        {
            var iSet = new HashSet<char>(words[i]);
            for (var j = i + 1; j < words.Length; j++)
            {
                var jSet = new HashSet<char>(words[j]);
                if (iSet.OrderBy(c => c).SequenceEqual(jSet.OrderBy(c => c)))
                {
                    result++;
                }
            }
        }
        return result;
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