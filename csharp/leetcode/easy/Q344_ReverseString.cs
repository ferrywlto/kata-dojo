
namespace dojo.leetcode;

public class Q344_ReverseString
{
    public void ReverseString(char[] s)
    {

    }
}

public class Q344_ReverseStringTestData: TestData
{
    protected override List<object[]> Data => 
    [
        [new char[]{'h','e','l','l','o'}, new char[]{'o','l','l','e','h'}],
        [new char[]{'H','a','n','n','a','h'}, new char[]{'h','a','n','n','a','H'}],
    ];
}

public class Q344_ReverseStringTests: BaseTest
{
    [Theory]
    [ClassData(typeof(Q344_ReverseStringTestData))]
    public void OfficialTestCases(char[] input, char[] expected)
    {
        var sut = new Q344_ReverseString();
        sut.ReverseString(input);
        Assert.True(Enumerable.SequenceEqual(expected, input));
    }
}