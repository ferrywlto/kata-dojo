class Q1913_MaxProductDiffBetweenTwoPairs
{
    // TC: O(n log n), due to Array.Sort();
    // SC: O(1), space used does not scale with input
    public int MaxProductDifference(int[] nums)
    {
        Array.Sort(nums);
        // Max diff must comes from lowest pair and highest pair
        return (nums[^1] * nums[^2]) - (nums[0] * nums[1]);
    }
}
class Q1913_MaxProductDiffBetweenTwoPairsTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int[] {5,6,2,7,4}, 34],
        [new int[] {4,2,5,9,7,4,8}, 64],
    ];
}
public class Q1913_MaxProductDiffBetweenTwoPairsTests
{
    [Theory]
    [ClassData(typeof(Q1913_MaxProductDiffBetweenTwoPairsTestData))]
    public void OfficialTestCases(int[] input, int expected)
    {
        var sut = new Q1913_MaxProductDiffBetweenTwoPairs();
        var actual = sut.MaxProductDifference(input);
        Assert.Equal(expected, actual);
    }
}