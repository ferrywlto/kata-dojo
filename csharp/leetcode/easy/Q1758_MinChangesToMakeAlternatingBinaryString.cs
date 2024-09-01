using System.Text;

class Q1758_MinChangesToMakeAlternatingBinaryString
{
    // TC: O(n), where n is the length of s
    // SC: O(1), space used is fixed
    public int MinOperations(string s)
    {
        var diffStartFromZero = 0;
        var diffStartFromOne = 0;
        for (var i = 0; i < s.Length; i++)
        {
            // Expected characters for alternating strings
            char expectedCharForZero = (i % 2 == 0) ? '0' : '1';
            char expectedCharForOne = (i % 2 == 0) ? '1' : '0';

            if (s[i] != expectedCharForZero) diffStartFromZero++;
            if (s[i] != expectedCharForOne) diffStartFromOne++;
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