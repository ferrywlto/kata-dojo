using System.Text;

class Q1758_MinChangesToMakeAlternatingBinaryString
{
    public string AlternateStr(string start, int length)
    {
        var sb = new StringBuilder(start);
        for (var i = 1; i < length; i++)
        {
            if (sb[i - 1] == '0') sb.Append('1');
            else sb.Append('0');
        }
        return sb.ToString();
    }
    // TC: O(n), where n is the length of s, n for create start from 0, n for create start from 1, and n to compare them with s;
    // SC: O(n), where n is the lenght of s, 2n for two string created
    public int MinOperations(string s)
    {
        var startWithZero = AlternateStr("0", s.Length);
        var startWithOne = AlternateStr("1", s.Length);
        var diffStartFromZero = 0;
        var diffStartFromOne = 0;
        for (var i = 0; i < s.Length; i++)
        {
            if (s[i] != startWithZero[i]) diffStartFromZero++;
            if (s[i] != startWithOne[i]) diffStartFromOne++;
        }
        return Math.Min(diffStartFromOne, diffStartFromZero);
    }
}
class Q1758_MinChangesToMakeAlternatingBinaryStringTestData : TestData
{
    protected override List<object[]> Data =>
    [
        ["0100", 1],
        ["10", 0],
        ["1111", 2],
        ["10010100", 3],
    ];
}
public class Q1758_MinChangesToMakeAlternatingBinaryStringTests
{
    [Theory]
    [ClassData(typeof(Q1758_MinChangesToMakeAlternatingBinaryStringTestData))]
    public void OfficialTestCases(string input, int expected)
    {
        var sut = new Q1758_MinChangesToMakeAlternatingBinaryString();
        var actual = sut.MinOperations(input);
        Assert.Equal(expected, actual);
    }
}