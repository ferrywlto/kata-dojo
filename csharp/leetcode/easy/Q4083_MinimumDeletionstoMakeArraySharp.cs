public class Q4083_MinimumDeletionstoMakeArraySharp
{
    // TC: O(n), n scale with length of nums
    // SC: O(1)
    public int MinDeletions(int[] nums)
    {
        if (nums.Length == 1) return 1;

        var result = 0;
        for (var i = 1; i < nums.Length; i++)
        {
            if (nums[i] == nums[i - 1]) result++;
        }

        return result;
    }

    public static TheoryData<int[], int> TestData => new()
    {
        { [1, 1, 2, 2, 2, 3], 3 },
        { [4, 4, 9, 4], 1 }
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = MinDeletions(input);
        Assert.Equal(expected, actual);
    }
}
