
namespace dojo.leetcode;

public class Q696_CountBinarySubstring
{
    public int CountBinarySubstrings(string s) 
    {
        return 0;
    }
}

public class Q696_CountBinarySubstringTestData : TestData
{
    protected override List<object[]> Data => 
    [
        ["00110011", 6],
        ["10101", 4],
    ];
}

public class Q696_CountBinarySubstringTests
{
    [Theory]
    [ClassData(typeof(Q696_CountBinarySubstringTestData))]
    public void OfficialTestCases(string input, int expected)
    {
        var sut = new Q696_CountBinarySubstring();
        var actual = sut.CountBinarySubstrings(input);
        Assert.Equal(expected, actual);
    }
}
