public class Q3146_PermutationDifferenceBetweenTwoStrings
{
    // TC: O(n+m), n scale with length of s and m scale with length of t
    // SC: O(n), n scale with length of s
    public int FindPermutationDifference(string s, string t)
    {
        var dict = new Dictionary<char, int>();
        for (var i = 0; i < s.Length; i++)
        {
            dict.Add(s[i], i);
        }
        var result = 0;
        for (var j = 0; j < t.Length; j++)
        {
            result += Math.Abs(dict[t[j]] - j);
        }
        return result;
    }
    public static TheoryData<string, string, int> TestData => new()
    {
        {"abc", "bac", 2},
        {"abcde", "edbac", 12},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input1, string input2, int expected)
    {
        var actual = FindPermutationDifference(input1, input2);
        Assert.Equal(expected, actual);
    }
}
