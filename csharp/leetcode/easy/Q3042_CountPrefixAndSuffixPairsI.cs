public class Q3042_CountPrefixAndSuffixPairsI
{
    // TC: O(n^2), n scale with length of words, have to iterate in nested loop to test all pairs
    // SC: O(1), space used does not scale with input 
    public int CountPrefixSuffixPairs(string[] words)
    {
        var result = 0;
        for (var i = 0; i < words.Length - 1; i++)
        {
            for (var j = i + 1; j < words.Length; j++)
            {
                if (IsPrefixAndSuffix(words[i], words[j]))
                {
                    result++;
                }
            }
        }
        return result;
    }
    private static bool IsPrefixAndSuffix(string str1, string str2)
    {
        if (str1.Length > str2.Length) return false;

        var j = str2.Length - str1.Length;
        for (var i = 0; i < str1.Length; i++)
        {
            if (str1[i] != str2[i] || str1[i] != str2[i + j]) return false;
        }
        return true;
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
