using System.Text;

public class Q3210_FindTheEncryptedString
{
    // TC: O(n), n scale with length of s
    // SC: O(1), space used does not scale with input
    public string GetEncryptedString(string s, int k)
    {
        var sb = new StringBuilder();
        for (var i = 0; i < s.Length; i++)
        {
            if (i + k >= s.Length)
                sb.Append(s[(i + k) % s.Length]);
            else
                sb.Append(s[i + k]);
        }
        return sb.ToString();
    }
    public static TheoryData<string, int, string> TestData => new()
    {
        {"dart", 3, "tdar"},
        {"aaa", 1, "aaa"},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, int k, string expected)
    {
        var actual = GetEncryptedString(input, k);
        Assert.Equal(expected, actual);
    }
}