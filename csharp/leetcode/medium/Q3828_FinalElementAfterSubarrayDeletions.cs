public class Q3828_FinalElementAfterSubarrayDeletions
{
    // TC: O(1)
    // SC: O(1)
    // This is because by observation, Alice must win if the largest element is at the head or tail on her move.
    // Same as Bob as they will eliminate as much elements as they could for optimal play. 
    // Whoever can push the largest/smallest element to the edge wins.
    // Thus only the head and tail elements matters.
    public int FinalElement(int[] nums)
    {
        return Math.Max(nums[0], nums[nums.Length - 1]);
    }

    public static TheoryData<int[], int> TestData => new()
    {
        {[1,5,2], 2},
        {[3,7], 7},
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = FinalElement(input);
        Assert.Equal(expected, actual);
    }
}
