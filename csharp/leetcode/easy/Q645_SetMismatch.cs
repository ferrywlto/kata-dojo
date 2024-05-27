class Q645_SetMismatch
{
    // TC: O(n log n) from Array.Sort()
    // SC: O(1)
    public int[] FindErrorNums(int[] nums)
    {
        Array.Sort(nums);

        var duplicate = -1;
        var sum = (1 + nums.Length) * nums.Length / 2;
        var temp = 0;
        for (var i = 0; i < nums.Length - 1; i++)
        {
            if (nums[i] == nums[i + 1])
            {
                duplicate = nums[i];
            }
            temp += nums[i];
        }
        temp += nums[^1];
        return [duplicate, sum - (temp - duplicate)];
    }
}

class Q645_SetMismatchTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int[]{1,2,2,4}, new int[]{2,3}],
        [new int[]{1,1}, new int[]{1,2}],
        [new int[]{3,2,3,4,6,5}, new int[]{3,1}],
        [new int[]{3,2,2,4,6,5}, new int[]{2,1}],
        [new int[]{3,2,2}, new int[]{2,1}],
        [new int[]{1,5,3,2,2,7,6,4,8,9}, new int[]{2,10}],
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
        Assert.Equal(expected, actual);
    }
}