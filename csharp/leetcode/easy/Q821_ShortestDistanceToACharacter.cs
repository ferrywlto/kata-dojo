
namespace dojo.leetcode;

public class Q821_ShortestDistanceToACharacter
{
    public int[] ShortestToChar(string s, char c) 
    {
        return [];    
    }
}

public class Q821_ShortestDistanceToACharacterTestData : TestData
{
    protected override List<object[]> Data => 
    [
        ["loveleetcode", 'e', new int[] { 3,2,1,0,1,0,0,1,2,2,1,0 }],
        ["aaab", 'b', new int[] { 3,2,1,0 }],
    ];
}

public class Q821_ShortestDistanceToACharacterTests
{
    [Theory]
    [ClassData(typeof(Q821_ShortestDistanceToACharacterTestData))]
    public void OfficialTestCases(string input, char character, int[] expected)
    {
        var sut = new Q821_ShortestDistanceToACharacter();
        var actual = sut.ShortestToChar(input, character);
        Assert.Equal(expected, actual);
    }
}