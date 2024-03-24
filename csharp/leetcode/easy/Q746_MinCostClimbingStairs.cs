
namespace dojo.leetcode;

public class Q746_MinCostClimbingStairs
{
    public int MinCostClimbingStairs(int[] cost) 
    {
        return 0;    
    }
}

public class Q746_MinCostClimbingStairsTestData : TestData
{
    protected override List<object[]> Data => 
    [
        [new int[]{10,15,20}, 15],
        [new int[]{1,100,1,1,1,100,1,1,100,1}, 6],
    ];
}

public class Q746_MinCostClimbingStairsTests
{
    [Theory]
    [ClassData(typeof(Q746_MinCostClimbingStairsTestData))]
    public void OfficialTestCases(int[] input, int expected)
    {
        var sut = new Q746_MinCostClimbingStairs();
        var actual = sut.MinCostClimbingStairs(input);
        Assert.Equal(expected, actual);
    }
}
