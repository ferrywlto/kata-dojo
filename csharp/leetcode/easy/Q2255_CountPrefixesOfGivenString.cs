public class Q2255_CountPrefixesOfGivenString
{
    // TC: O(n), where n sacle with number of total characters in words
    // SC: O(1), space used does not sacle with input
    public int CountPrefixes(string[] words, string s)
    {
        var result = 0;
        foreach (var word in words)
        {
            for (var i = 0; i < word.Length; i++)
            {
                if (i >= s.Length) break;
                if (word[i] != s[i]) break;
                else if (i == word.Length - 1) result++;
            }
        }
        return result;
    }
    public static List<object[]> TestData =>
    [
        [new string[] {"a","b","c","ab","bc","abc"}, "abc", 3],
        [new string[] {"a","a"}, "aa", 2],
        [new string[] {"ab","abc"}, "a", 0],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string[] input, string s, int expected)
    {
        var actual = CountPrefixes(input, s);
        Assert.Equal(expected, actual);
    }
}