public class Q2744_FindMaxStringPairs
{
    // TC: O(n), n scale with length of words in single pass
    // SC: O(n), same as time.
    public int MaximumNumberOfStringPairs(string[] words)
    {
        var result = 0;
        var tree = new Trie();
        foreach (var w in words)
        {
            if (tree.SearchReverse(w)) result++;
            else tree.Insert(w);
        }
        return result;
    }
    public static TheoryData<string[], int> TestData => new()
    {
        {["cd","ac","dc","ca","zz"], 2},
        {["ab","ba","cc"], 1},
        {["aa","ab"], 0},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string[] input, int expected)
    {
        var actual = MaximumNumberOfStringPairs(input);
        Assert.Equal(expected, actual);
    }
}