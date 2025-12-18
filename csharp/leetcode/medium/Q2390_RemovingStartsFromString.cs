using System.Text;

public class Q2390_RemovingStartsFromString
{
    // TC: O(n), n scale with length of s
    // SC: O(n), for string builder
    public string RemoveStars(string s)
    {
        var sb = new StringBuilder();
        foreach (var c in s)
        {
            if (c == '*')
                sb.Remove(sb.Length - 1, 1);
            else
                sb.Append(c);
        }
        return sb.ToString();
    }

    public static TheoryData<string, string> TestData => new()
    {
        {"leet**cod*e", "lecoe"},
        {"erase*****", ""},
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, string expected)
    {
        var actual = RemoveStars(input);
        Assert.Equal(expected, actual);
    }
}
