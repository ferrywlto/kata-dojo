public class Q3016_MinNumberOfPushesToTypeWordII(ITestOutputHelper output)
{
    // TC: O(n), n scale with length of word
    // SC: O(1), space used does not scale with input
    public int MinimumPushes(string word)
    {
        var count = new int[26];
        for (var i = 0; i < word.Length; i++)
        {
            count[word[i] - 'a']++;
        }

        Array.Sort(count);
        output.WriteLine(string.Join(",", count));
        var result = 0;
        for (var i = 25; i >= 0; i--)
        {
            if (i > 17)
            {
                result += count[i];
            }
            else if (i > 9)
            {
                result += count[i] * 2;
            }
            else if (i > 1)
            {
                result += count[i] * 3;
            }
            else
            {
                result += count[i] * 4;
            }
        }
        return result;
    }
    public static TheoryData<string, int> TestData => new()
    {
        {"abcde", 5},
        {"xyzxyzxyzxyz", 12},
        {"aabbccddeeffgghhiiiiii", 24},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void MinimumPushes_ShouldReturnExpectedResult(string word, int expected)
    {
        var result = MinimumPushes(word);
        Assert.Equal(expected, result);
    }
}
