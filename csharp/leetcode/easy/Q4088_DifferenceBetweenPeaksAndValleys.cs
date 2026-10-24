public class Q4088_DifferenceBetweenPeaksAndValleys
{
    // TC: O(n)
    // SC: O(1)
    public int PeakValleyDifference(int[] nums)
    {
        var result = 0;
        for (var i = 1; i < nums.Length - 1; i++)
        {
            if (nums[i] > nums[i + 1] && nums[i] > nums[i - 1])
            {
                result += nums[i];
            }
            else if (nums[i] < nums[i + 1] && nums[i] < nums[i - 1])
            {
                result -= nums[i];
            }
        }

        return result;
    }

    public static TheoryData<int[], int> TestData => new()
    {
        { [1, 5, 2, 4, 1, 3, 0], 9 },
        { [-5, -6, -1, -2, 5, 3, 2], 12 },
        { [6, 5, 2, 5, 5, 3, 6], -5 },
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = PeakValleyDifference(input);
        Assert.Equal(expected, actual);
    }
}
