class Q896_MonotonicArray
{
    // TC: O(n), n is length of nums, it have to iterate all items except the first once
    // SC: O(1), no extra memory used
    public bool IsMonotonic(int[] nums)
    {
        if (nums.Length <= 1) return true;

        // 0 is init
        // 1 is upward
        // -1 is downward
        int direction = 0;
        for (var i = 1; i < nums.Length; i++)
        {
            if (nums[i] > nums[i - 1])
            {
                if (direction == 0) direction = 1;
                else if (direction == -1) return false;
            }
            else if (nums[i] < nums[i - 1])
            {
                if (direction == 0) direction = -1;
                else if (direction == 1) return false;
            }
        }
        return true;
    }
}

class Q896_MonotonicArrayTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int[]{1,2,2,3}, true],
        [new int[]{6,5,4,4}, true],
        [new int[]{1,3,2}, false],
        [new int[]{-1,-2,-2,-3}, true],
        [new int[]{-6,-5,-4,-4}, true],
        [new int[]{-1,-3,-2}, false],
        [new int[]{-1,0,1}, true],
        [new int[]{0,0,0}, true],
        [new int[]{0}, true],
        [Array.Empty<int>(), true],
    ];
}

public class Q896_MonotonicArrayTests
{
    [Theory]
    [ClassData(typeof(Q896_MonotonicArrayTestData))]
    public void OfficialTestCases(int[] input, bool expected)
    {
        var sut = new Q896_MonotonicArray();
        var actual = sut.IsMonotonic(input);
        Assert.Equal(expected, actual);
    }
}
