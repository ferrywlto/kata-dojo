
namespace dojo.leetcode;

public class Q628_MaxProductOfThreeNumbers
{
    public int MaximumProduct(int[] nums) 
    {
        if (nums.Length == 3) 
            return nums[0] * nums[1] * nums[2];

        var max = int.MinValue;
        for(var i=0; i<nums.Length; i++)
        {
            for(var j=i+1; j<nums.Length; j++)
            {
                for(var k=j+1; k<nums.Length; k++)
                {
                    var product = nums[i] * nums[j] * nums[k];
                    if (product > max) max = product;
                }
            }
        }
        return max;
    }
}

public class Q628_MaxProductOfThreeNumbersTestData : TestData
{
    protected override List<object[]> Data => 
    [
        [new int[] {1,2,3}, 6],
        [new int[] {1,2,3,4}, 24],
        [new int[] {-1,-2,-3}, -6],
    ];
}

public class Q628_MaxProductOfThreeNumbersTests
{
    [Theory]
    [ClassData(typeof(Q628_MaxProductOfThreeNumbersTestData))]
    public void OfficialTestCases(int[] input, int expected)
    {
        var sut = new Q628_MaxProductOfThreeNumbers();
        var actual = sut.MaximumProduct(input);
        Assert.Equal(actual, expected);
    }
}