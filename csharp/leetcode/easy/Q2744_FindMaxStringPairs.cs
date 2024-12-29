public class Q2744_FindMaxStringPairs
{
    // TC: O(n), n scale with length of words in single pass
    // SC: O(n), same as time.
    // It is possible to use tree to speed up the matching, but is it worth?
    public int MaximumNumberOfStringPairs(string[] words)
    {
        var result = 0;
        var set = new HashSet<string>();
        foreach (var w in words)
        {
            var reverse = new string(w.Reverse().ToArray());

            if (set.Contains(reverse!)) result++;

            set.Add(w);
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