class Q628_MaxProductOfThreeNumbers
{
    // TC: O(n log n)
    // SC: O(1)
    public int MaximumProduct(int[] nums) 
    {
        if (nums.Length == 3) 
            return nums[0] * nums[1] * nums[2];

        Array.Sort(nums);
        return Math.Max(nums[0] * nums[1] * nums[^1], nums[^3] * nums[^2] * nums[^1]);
    }
}

class Q628_MaxProductOfThreeNumbersTestData : TestData
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