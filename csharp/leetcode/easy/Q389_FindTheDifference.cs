namespace dojo.leetcode;

public class Q389_FindTheDifference
{
    public char FindTheDifference(string s, string t)
    {
        return 'c';
    }
}

public class Q389_FindTheDifferenceTestData: TestData
{
    protected override List<object[]> Data => new List<object[]>
    {
        new object[] {"abcd", "abcde", 'e'},
        new object[] {"", "y", 'y'},
        new object[] {"a", "aa", 'a'},
        new object[] {"ae", "aea", 'a'},
        new object[] {"a", "a", 'a'},
    };
}

public class Q389_FindTheDifferenceTests
{
    [Theory]
    [ClassData(typeof(Q389_FindTheDifferenceTestData))]
    public void OfficialTestCases(string s, string t, char expected)
    {
        var q = new Q389_FindTheDifference();
        char result = q.FindTheDifference(s, t);
        Assert.Equal(expected, result);
    }
}