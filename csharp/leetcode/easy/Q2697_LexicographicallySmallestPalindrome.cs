using System.Text;

public class Q2697_LexicographicallySmallestPalindrome
{
    // TC: O(n), n scale with length of s divide by 2
    // SC: O(n), n scale with length of s to hold in string builder
    public string MakeSmallestPalindrome(string s)
    {
        var sb = new StringBuilder(s);
        for (var i = 0; i < sb.Length / 2; i++)
        {
            var head = sb[i];
            var tail = sb[^(i + 1)];
            if (head != tail)
            {
                var smaller = Math.Min(sb[i], sb[^(i + 1)]);
                sb[i] = (char)smaller;
                sb[^(i + 1)] = (char)smaller;
            }
        }
        return sb.ToString();
    }

    public static TheoryData<string, string> TestData => new()
    {
        {"egcfe", "efcfe"},
        {"abcd", "abba"},
        {"seven", "neven"},
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, string expected)
    {
        var actual = MakeSmallestPalindrome(input);
        Assert.Equal(expected, actual);
    }
}