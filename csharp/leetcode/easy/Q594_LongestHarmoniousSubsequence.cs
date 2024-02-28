
namespace dojo.leetcode;

public class Q594_LongestHarmoniousSubsequence
{
    public int FindLHS(int[] nums) 
    {
        return 0;    
    }
}

public class Q594_LongestHarmoniousSubsequenceTestData : TestData
{
    protected override List<object[]> Data => 
    [
        [new int[]{1,3,2,2,5,2,3,7}, 5],
        [new int[]{1,2,3,4}, 2],
        [new int[]{1,1,1,1}, 0],
    ];
} 

public class Q594_LongestHarmoniousSubsequenceTests
{
    [Theory]
    [ClassData(typeof(Q594_LongestHarmoniousSubsequenceTestData))]
    public void OfficialTestCases(int[] input, int expected)
    {
        var sut = new Q594_LongestHarmoniousSubsequence();
        var actual = sut.FindLHS(input);
        Assert.Equal(expected, actual);
    }

}