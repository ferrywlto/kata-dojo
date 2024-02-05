namespace dojo.leetcode;

public class Q387_FirstUniqueCharacter
{
    public int FirstUniqChar(string s) 
    {
        return -1;
    }
}

public class Q387_FirstUniqueCharacterTestData: TestData
{
    protected override List<object[]> Data => 
    [
        ["leetcode", 0],
        ["loveleetcode", 2],
        ["aabb", -1],
    ];
}

public class Q387_FirstUniqueCharacterTests
{
    [Theory]
    [ClassData(typeof(Q387_FirstUniqueCharacterTestData))]
    public void OfficialTestCases(string s, int expected)
    {
        var q = new Q387_FirstUniqueCharacter();
        int result = q.FirstUniqChar(s);
        Assert.Equal(expected, result);
    }
}