public class Q1967_NumStringsAppearSubstringsInWords
{
    // TC: O(n*m), n scales with total characters in patterns times total characters in word
    // SC: O(1), space used does not scale with input
    public int NumOfStrings(string[] patterns, string word)
    {
        var result = 0;
        foreach (var pattern in patterns)
        {
            if (pattern.Length > word.Length) continue;

            // two pointers
            // find first char match
            for (var i = 0; i <= word.Length - pattern.Length; i++)
            {
                var j = 0;
                while (j < pattern.Length && word[i + j] == pattern[j]) j++;

                if (j == pattern.Length)
                {
                    result++;
                    break;
                }
            }
        }
        return result;
    }
    public static List<object[]> TestData =>
    [
        [new string[] {"a","abc","bc","d"}, "abc", 3],
        [new string[] {"a", "b", "c"}, "aaaaabbbbb", 2],
        [new string[] {"a","a","a"}, "ab", 3],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string[] input, string word, int expected)
    {
        var actual = NumOfStrings(input, word);
        Assert.Equal(expected, actual);
    }
}
