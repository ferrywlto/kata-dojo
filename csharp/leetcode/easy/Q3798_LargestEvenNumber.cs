using System.Text;

public class Q3798_LargestEvenNumber
{
    // TC: O(n), n scale with length of s
    // SC: O(n), to hold the result, worst case n = s.Length for already even number
    public string LargestEven(string s)
    {
        var sb = new StringBuilder(s);
        while (sb.Length > 0 && sb[^1] == '1') sb.Length--;
        return sb.ToString();
    }
    public static TheoryData<string, string> TestData => new()
    {
        {"1112", "1112"},
        {"221", "22"},
        {"1", ""},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, string expected)
    {
        var actual = LargestEven(input);
        Assert.Equal(expected, actual);
    }
}
