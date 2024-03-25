
namespace dojo.leetcode;

public class Q747_LargestNumberAtLeastTwiceOfOthers
{
    public int DominantIndex(int[] nums) 
    {
        return -1;    
    }    
}

public class Q747_LargestNumberAtLeastTwiceOfOthersTestData : TestData
{
    protected override List<object[]> Data => 
    [
        [new int[]{3,6,1,0}, 1],
        [new int[]{1,2,3,4}, -1],
    ];
}

public class Q747_LargestNumberAtLeastTwiceOfOthersTests
{
    [Theory]
    [ClassData(typeof(Q747_LargestNumberAtLeastTwiceOfOthersTestData))]
    public void OfficialTestCases(int[] input, int expected)
    {
        var sut = new Q747_LargestNumberAtLeastTwiceOfOthers();
        var actual = sut.DominantIndex(input);
        Assert.Equal(expected, actual);
    }
}
