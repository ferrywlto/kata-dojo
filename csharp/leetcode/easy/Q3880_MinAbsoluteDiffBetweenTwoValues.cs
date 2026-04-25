public class Q3880_MinAbsoluteDiffBetweenTwoValues
{
    // TC: O(n), n scale with length of nums
    // SC: O(1), space used does not scale with input
    public int MinAbsoluteDifference(int[] nums)
    {
        var idx1 = -1;
        var idx2 = -1;

        var minDiff = int.MaxValue;
        for (var i = 0; i < nums.Length; i++)
        {
            if (nums[i] == 1) idx1 = i;
            else if (nums[i] == 2) idx2 = i;

            if (idx1 != -1 && idx2 != -1)
            {
                var diff = Math.Abs(idx1 - idx2);
                if (diff < minDiff)
                    minDiff = diff;
            }
        }

        if (minDiff == int.MaxValue) return -1;
        return minDiff;
    }

    public static TheoryData<int[], int> TestData => new() { { [1, 0, 0, 2, 0, 1], 2 }, { [1, 0, 1, 0], -1 } };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = MinAbsoluteDifference(input);
        Assert.Equal(expected, actual);
    }
}
