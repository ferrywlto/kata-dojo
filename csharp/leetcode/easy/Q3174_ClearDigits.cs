using System.Text;

public class Q3174_ClearDigits
{
    // TC: O(n), n scale with length of s
    // SC: O(n), same as time, worst case the whole s is stored. (no digits)
    public string ClearDigits(string s)
    {
        var sb = new StringBuilder();
        foreach (var c in s)
        {
            if (char.IsDigit(c) && sb.Length > 0) sb.Remove(sb.Length - 1, 1);
            else sb.Append(c);
        }
        return sb.ToString();
    }
    public static TheoryData<string, string> TestData => new()
    {
        {"abc", "abc"},
        {"cb34", ""},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, string expected)
    {
        var actual = ClearDigits(input);
        Assert.Equal(expected, actual);
    }
}