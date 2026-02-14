using System.Text;

public class Q2810_FaultyKeyboard
{
    // TC: O(n), n scale with length of s
    // SC: O(n), same as time
    public string FinalString(string s)
    {
        var sb = new StringBuilder();
        for (var i = 0; i < s.Length; i++)
        {
            if (s[i] != 'i')
            {
                sb.Append(s[i]);
            }
            else
            {
                for (var j = 0; j < sb.Length / 2; j++)
                {
                    (sb[^(j + 1)], sb[j]) = (sb[j], sb[^(j + 1)]);
                }
            }
        }

        return sb.ToString();
    }
    public static TheoryData<string, string> TestData => new()
    {
        {"string", "rtsng"},
        {"poiinter", "ponter"},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, string expected)
    {
        var actual = FinalString(input);
        Assert.Equal(expected, actual);
    }
}
