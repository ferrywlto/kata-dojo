public class Q2506_CountPairsOfSimilarStrings
{
    // TC: O(n^2)
    // SC: O(n), n scale with length of words * 26 characters
    public int SimilarPairs(string[] words)
    {
        var result = 0;

        var chars = new int[words.Length][];
        for (var i = 0; i < chars.Length; i++)
        {
            chars[i] = new int[26];
        }

        for (var i = 0; i < words.Length; i++)
        {
            var word = words[i];
            foreach (var c in word)
            {
                chars[i][c - 'a']++;
            }
        }

        for (var i = 0; i < words.Length - 1; i++)
        {
            for (var j = i + 1; j < words.Length; j++)
            {
                var similar = true;
                for (var k = 0; k < 26; k++)
                {
                    if (
                        (chars[i][k] > 0 && chars[j][k] == 0) ||
                        (chars[i][k] == 0 && chars[j][k] > 0)
                    )
                    {
                        similar = false;
                        break;
                    }
                }
                if (similar) result++;
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
