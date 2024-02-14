
namespace dojo.leetcode;

public class Q485_MaxConsecutiveOnes
{
    public int FindMaxConsecutiveOnes(int[] nums)
    {
        return 0;
    }
}

public class Q485_MaxConsecutiveOnesTestData: TestData
{
    protected override List<object[]> Data => 
    [
        [new int[] {1,1,0,1,1,1}, 3],
        [new int[] {1,0,1,1,0,1}, 2],
        [new int[] {0,0,0,0,0,0}, 0],
        [new int[] {1,1,1,1,1,1}, 6],        
        [new int[] {1,1,1,0,0,0}, 3],
    ];
}

public class Q485_MaxConsecutiveOnesTests
{
    [Theory]
    [ClassData(typeof(Q485_MaxConsecutiveOnesTestData))]
    public void OfficialTestCases(int[] nums, int expected)
    {
        var sut = new Q485_MaxConsecutiveOnes();
        var actual = sut.FindMaxConsecutiveOnes(nums);
        Assert.Equal(expected, actual);
    }
}