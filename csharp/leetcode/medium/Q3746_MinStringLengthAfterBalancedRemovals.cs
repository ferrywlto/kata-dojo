public class Q3746_MinStringLengthAfterBalancedRemovals
{
    // TC: O(n), n scale with length of s
    // SC: O(n), worst case stack will hold all characters
    public int MinLengthAfterRemovals(string s)
    {
        var stack = new Stack<char>();
        foreach (var c in s)
        {
            if (stack.Count > 0 && stack.Peek() != c)
                stack.Pop();
            else
                stack.Push(c);
        }
        return stack.Count();
    }
    public static TheoryData<string, int> TestData => new()
    {
        {"aabbab", 0},
        {"aaaa", 4},
        {"aaabb", 1},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, int expected)
    {
        var actual = MinLengthAfterRemovals(input);
        Assert.Equal(expected, actual);
    }
}
