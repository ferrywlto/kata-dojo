using System.Text;

public class Q3794_ReverseStringPrefix
{
    // TC: O(k), only k/2 operation needed
    // SC: O(m), m scale with length of s to hold the result
    public string ReversePrefix(string s, int k)
    {
        var sb = new StringBuilder(s);
        for (var i = 0; i < k / 2; i++)
        {
            var tailIdx = k - i - 1;
            (sb[tailIdx], sb[i]) = (sb[i], sb[tailIdx]);
        }
        return sb.ToString();
    }
    public static TheoryData<string, int, string> TestData => new()
    {
        {"abcd", 2, "bacd"},
        {"xyz", 3, "zyx"},
        {"hey", 1, "hey"},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, int k, string expected)
    {
        var actual = ReversePrefix(input, k);
        Assert.Equal(expected, actual);
    }

}
