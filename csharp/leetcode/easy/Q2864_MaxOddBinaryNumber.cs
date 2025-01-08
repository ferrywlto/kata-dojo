using System.Text;

public class Q2864_MaxOddBinaryNumber
{
    // TC: O(n), n scale with length of s
    // SC: O(n), same as time to hold the result
    public string MaximumOddBinaryNumber(string s)
    {
        var oneCount = 0;
        for (var i = 0; i < s.Length; i++)
        {
            if (s[i] == '1') oneCount++;
        }
        var sb = new StringBuilder();
        for (var j = 0; j < oneCount - 1; j++)
        {
            sb.Append('1');
        }
        for (var k = 0; k < s.Length - oneCount; k++)
        {
            sb.Append('0');
        }
        sb.Append('1');

        return sb.ToString();
    }
    public static TheoryData<string, string> TestData => new()
    {
        {"010", "001"},
        {"0101", "1001"},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, string expected)
    {
        var actual = MaximumOddBinaryNumber(input);
        Assert.Equal(expected, actual);
    }
}