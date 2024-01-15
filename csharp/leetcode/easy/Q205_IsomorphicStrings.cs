
namespace dojo.leetcode;

public class Q205_IsomorphicStrings
{
    public bool IsIsomorphic(string s, string t)
    {
        return false;
    }
}

public class Q205_IsomorphicStringsTestData : TestData
{
    protected override List<object[]> Data => 
    [
        ["egg", "add", true],
        ["foo", "bar", false],
        ["paper", "title", true]
    ];
}

public class Q205_IsomorphicStringsTest(ITestOutputHelper output): BaseTest(output)
{
    [Theory]
    [ClassData(typeof(Q205_IsomorphicStringsTestData))]
    public void OfficialTestCases(string input1, string input2, bool expected)
    {
        var sut = new Q205_IsomorphicStrings();
        var actual = sut.IsIsomorphic(input1, input2);

        Assert.Equal(expected, actual);
    }
}