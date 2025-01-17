public class Q2900_LongestUnequalAdjacentGroupsSubsequenceI
{
    public IList<string> GetLongestSubsequence(string[] words, int[] groups)
    {
        return [];
    }
    public static TheoryData<string[], int[], List<string>> TestData => new()
    {
        {["e","a","b"], [0,0,1], ["e","b"]},
        {["a","b","c","d"], [1,0,1,1], ["a","b","c"]},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string[] input, int[] groups, string[] expected)
    {
        var actual = GetLongestSubsequence(input, groups);
        Assert.Equal(expected, actual);
    }
}