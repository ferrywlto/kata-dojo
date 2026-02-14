public class Q3120_CountNumberOfSpecialCharactersI
{
    // TC: O(n), n scale with length of word
    // SC: O(1), space used does not sacle with input
    public int NumberOfSpecialChars(string word)
    {
        var lowerChars = new int[26];
        var upperChars = new int[26];
        var result = 0;
        foreach (var c in word)
        {
            if (char.IsLower(c))
            {
                lowerChars[c - 'a']++;
            }
            else
            {
                upperChars[c - 'A']++;
            }
        }
        for (var i = 0; i < lowerChars.Length; i++)
        {
            if (lowerChars[i] > 0 && upperChars[i] > 0) result++;
        }
        return result;
    }
    public static TheoryData<string, int> TestData => new()
    {
        {"aaAbcBC", 3},
        {"abc", 0},
        {"abBCab", 1},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, int expected)
    {
        var actual = NumberOfSpecialChars(input);
        Assert.Equal(expected, actual);
    }
}
