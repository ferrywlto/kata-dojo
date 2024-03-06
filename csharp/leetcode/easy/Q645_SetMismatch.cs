
namespace dojo.leetcode;

public class Q645_SetMismatch
{
    public int[] FindErrorNums(int[] nums) 
    {
        return [];    
    }
}

public class Q645_SetMismatchTestData : TestData
{
    protected override List<object[]> Data => 
    [
        [new int[]{1,2,3,4}, new int[]{2,3}],
        [new int[]{1,1}, new int[]{1,2}],
    ];
}

public class Q645_SetMismatchTests
{
    [Theory]
    [ClassData(typeof(Q645_SetMismatchTestData))]
    public void OfficialTestCases(int[] input, int[] expected)
    {
        var sut = new Q645_SetMismatch();
        var actual = sut.FindErrorNums(input);
        Assert.Equal(expected, input);
    }
}