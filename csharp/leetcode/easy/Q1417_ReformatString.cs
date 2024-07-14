using System.Text;

class Q1417_ReformatString
{
    // TC: O(n), n is the length of s, first n to analyse the frequency, another n for forming the result string
    // SC: O(n), n is the length of s
    public string Reformat(string s) 
    {
        if (s.Length == 1) return s;

        var chars = new Stack<char>();
        var nums = new Stack<char>();
        foreach(var c in s)
        {
            if (char.IsAsciiDigit(c)) nums.Push(c);
            else if (char.IsAsciiLetterLower(c)) chars.Push(c);
        }
        var lengthDiff = Math.Abs(chars.Count - nums.Count);
        if (chars.Count == 0 || nums.Count == 0 || lengthDiff > 1) return string.Empty;

        var sb = new StringBuilder();
        if(chars.Count > nums.Count) 
        {
            sb.Append(chars.Pop());
        }
        while(chars.Count > 0 && nums.Count > 0)
        {
            sb.Append(nums.Pop());
            sb.Append(chars.Pop());
        }
        if (chars.Count < nums.Count)
        {
            sb.Append(nums.Pop());
        }
        return sb.ToString();
    }
}
class Q1417_ReformatStringTestData : TestData
{
    protected override List<object[]> Data => 
    [
        ["a0b1c2", "2c1b0a"],
        ["leetcode", string.Empty],
        ["1229857369", string.Empty],
        ["j", "j"],
        ["1", "1"],
    ];
}
public class Q1417_ReformatStringTests
{
    [Theory]
    [ClassData(typeof(Q1417_ReformatStringTestData))]
    public void OfficialTestCases(string input, string expected)
    {
        var sut = new Q1417_ReformatString();
        var actual = sut.Reformat(input);
        Assert.Equal(expected, actual);
    }
}
