
namespace dojo.leetcode;

public class Q717_OneAndTwoBitCharacters
{
    public bool IsOneBitCharacter(int[] bits) 
    {
        return false;    
    }
}

public class Q717_OneAndTwoBitCharactersTestData : TestData
{
    protected override List<object[]> Data => 
    [
        [new int[]{1,0,0}, true],
        [new int[]{1,1,1,0}, false],
    ];
}

public class Q717_OneAndTwoBitCharactersTests
{
    [Theory]
    [ClassData(typeof(Q717_OneAndTwoBitCharactersTestData))]
    public void OfficialTestCases(int[] input, bool expected)
    {
        var sut = new Q717_OneAndTwoBitCharacters();
        var actual = sut.IsOneBitCharacter(input);
        Assert.Equal(expected, actual);
    }
}
