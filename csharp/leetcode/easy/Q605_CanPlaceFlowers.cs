
namespace dojo.leetcode;

public class Q605_CanPlaceFlowers
{
    public bool CanPlaceFlowers(int[] flowerbed, int n) 
    {
        return false;   
    }
}

public class Q605_CanPlaceFlowersTestData: TestData
{
    protected override List<object[]> Data => 
    [
        [new int[]{1,0,0,0,1}, 1, true],
        [new int[]{1,0,0,0,1}, 2, false],
    ];
}


public class Q605_CanPlaceFlowersTests
{
    [Theory]
    [ClassData(typeof(Q605_CanPlaceFlowersTestData))]
    public void OfficialTestCases(int[] input, int pots, bool expected)
    {
        var sut = new Q605_CanPlaceFlowers();
        var actual = sut.CanPlaceFlowers(input, pots);
        Assert.Equal(expected, actual);
    }
}