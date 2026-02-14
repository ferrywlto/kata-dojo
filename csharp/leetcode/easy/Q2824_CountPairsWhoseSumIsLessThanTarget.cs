public class Q2824_CountPairsWhoseSumIsLessThanTarget
{
    public int CountPairs(IList<int> nums, int target)
    {
        var result = 0;
        for (var i = 0; i < nums.Count - 1; i++)
        {
            for (var j = i + 1; j < nums.Count; j++)
            {
                if (nums[i] + nums[j] < target) result++;
            }
        }
        return result;
    }
    public static TheoryData<int[], int, int> TestData => new()
    {
        {[-1,1,2,3,1], 2, 3},
        {[-6,2,5,-2,-7,-1,3], -2, 10},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int t, int expected)
    {
        var actual = CountPairs(input, t);
        Assert.Equal(expected, actual);
    }
}
