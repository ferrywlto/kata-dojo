public class Q2696_MinStringLengthAfterRemovingSubstrings
{
    // TC: O(n), n scale with length of s
    // SC: O(n), space used equals to length of s in worst case
    public int MinLength(string s)
    {
        var stack = new Stack<char>();
        var removed = 0;
        for (var i = 0; i < s.Length; i++)
        {
            if
            (
                (stack.Count > 0) &&
                (
                    (s[i] == 'B' && stack.Peek() == 'A') ||
                    (s[i] == 'D' && stack.Peek() == 'C')
                )
            )
            {
                stack.Pop();
                removed += 2;
            }
            else stack.Push(s[i]);
        }

        return s.Length - removed;
    }
    public static TheoryData<string, int> TestData => new()
    {
        {"ABFCACDB", 2},
        {"ACBBD", 5},
        {"D", 1},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, int expected)
    {
        var actual = MinLength(input);
        Assert.Equal(expected, actual);
    }
}
