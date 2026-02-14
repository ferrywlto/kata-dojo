public class Q3637_TrionicArrayI
{
    // TC: O(n), n scale with length of nums
    // SC: O(1), space used does not scale with input
    public bool IsTrionic(int[] nums)
    {
        if (nums.Length < 4) return false;
        var direction = 0;
        var flip = 0;
        for (var i = 1; i < nums.Length; i++)
        {
            if (nums[i] > nums[i - 1])
            {
                if (direction != 1)
                {
                    direction = 1;
                    flip++;
                }
            }
            else if (nums[i] < nums[i - 1])
            {
                if (direction == 0) return false;
                else if (direction == 1)
                {
                    direction = -1;
                    flip++;
                }
            }
            else return false;
        }
        return flip == 3;
    }
    public static TheoryData<int[], bool> TestData => new()
    {
        { [1,3,5,4,2,6], true },
        { [2,1,3], false },
        { [9,2,9,1], false },
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] nums, bool expected)
    {
        var actual = IsTrionic(nums);
        Assert.Equal(expected, actual);
    }
}
