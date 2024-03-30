
namespace dojo.leetcode;

public class Q771_JewelsAndStones
{
    public int NumJewelsInStones(string jewels, string stones) 
    {
        return 0;    
    }    
}

public class Q771_JewelsAndStonesTestData : TestData
{
    protected override List<object[]> Data =>
    [
        ["aA", "aAAbbbb", 3],
        ["z", "ZZ", 0],
    ];
}

public class Q771_JewelsAndStonesTests
{
    [Theory]
    [ClassData(typeof(Q771_JewelsAndStonesTestData))]
    public void OfficialTestCases(string jewels, string stones, int expected)
    {
        var sut = new Q771_JewelsAndStones();
        var actual = sut.NumJewelsInStones(jewels, stones);
        Assert.Equal(expected, actual);
    }
}