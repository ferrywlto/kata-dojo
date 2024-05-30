class Q1047_RemoveAllAdjacentDuplicates
{
    // TC: O(n), n is length of s
    // SC: O(n), n is length of s in worst cases
    public string RemoveDuplicates(string s)
    {
        if (s.Length <= 1) return s;
        var stack = new Stack<char>();
        stack.Push(s[0]);
        for (var i = 1; i < s.Length; i++)
        {
            if (stack.Count > 0 && s[i] == stack.Peek())
            {
                while (stack.Count > 0 && s[i] == stack.Peek())
                {
                    stack.Pop();
                }
            }
            else stack.Push(s[i]);
        }

        return string.Join(string.Empty,stack.Reverse());
    }
}
class Q1047_RemoveAllAdjacentDuplicatesTestData : TestData
{
    protected override List<object[]> Data =>
    [
        ["abbaca", "ca"],
        ["azxxzy", "ay"],
    ];
}
public class Q1047_RemoveAllAdjacentDuplicatesTests
{
    [Theory]
    [ClassData(typeof(Q1047_RemoveAllAdjacentDuplicatesTestData))]
    public void OfficialTestCases(string input, string expected)
    {
        var sut = new Q1047_RemoveAllAdjacentDuplicates();
        var actual = sut.RemoveDuplicates(input);
        Assert.Equal(expected, actual);
    }
}