public class Q1984_MinDiffBetweenHighestAndLowestKScores
{

    // TC: O(n log n), due to Array.Sort() + (n - k) 
    // SC: O(1), space used does not scale with nums or k
    public int MinimumDifference(int[] nums, int k)
    {
        if (k == 1) return 0;

        Array.Sort(nums);
        var min = int.MaxValue;
        for (var i = 0; i < nums.Length - k + 1; i++)
        {
            var diff = Math.Abs(nums[i] - nums[i + k - 1]);
            if (diff < min) min = diff;
        }
        return min;
    }
    public static List<object[]> TestData =>
    [
        [new int[] {90}, 1, 0],
        [new int[] {9,4,1,7}, 2, 2],
        [new int[] {87063,61094,44530,21297,95857,93551,9918}, 6, 74560],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int k, int expected)
    {
        var actual = MinimumDifference(input, k);
        Assert.Equal(expected, actual);
    }
}
