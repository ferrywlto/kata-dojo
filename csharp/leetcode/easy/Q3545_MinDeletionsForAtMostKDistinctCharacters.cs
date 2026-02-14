public class Q3545_MinDeletionsForAtMostKDistinctCharacters
{
    // TC: O(n log n), n scale with length of s, due to Array.Sort(), but the constraints is small s.Length <= 16
    // Non sorting approach can be faster, but not worth the effort
    // SC: O(1), space used does not scale with input
    public int MinDeletion(string s, int k)
    {
        var freq = new int[26];
        for (var i = 0; i < s.Length; i++)
        {
            freq[s[i] - 'a']++;
        }
        Array.Sort(freq);

        var result = 0;
        for (var j = freq.Length - k - 1; j >= 0; j--)
        {
            result += freq[j];
        }
        return result;
    }
    public static TheoryData<string, int, int> TestData => new()
    {
        {"abc", 2, 1},
        {"aabb", 2, 0},
        {"yyyzz", 1, 2},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, int k, int expected)
    {
        var actual = MinDeletion(input, k);
        Assert.Equal(expected, actual);
    }
}
