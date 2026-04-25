public class Q3847_FindScoreDiffInGame
{
    // TC: O(n), n scale with length of nums
    // SC: O(1), space used does not scale with input
    public int ScoreDifference(int[] nums)
    {
        Span<int> scores = stackalloc int[2];
        var idx = 0;
        for (var i = 0; i < nums.Length; i++)
        {
            if (i % 6 == 5)
                idx = idx == 0 ? 1 : 0;

            if (nums[i] % 2 == 1)
                idx = idx == 0 ? 1 : 0;

            scores[idx] += nums[i];
        }

        return scores[0] - scores[1];
    }

    public static TheoryData<int[], int> TestData => new() { { [1, 2, 3], 0 }, { [2, 4, 2, 1, 2, 1], 4 }, { [1], -1 } };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = ScoreDifference(input);
        Assert.Equal(expected, actual);
    }
}
