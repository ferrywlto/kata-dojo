public class Q3349_AdjacentIncreasingSubarraysDetectionI
{
    public bool HasIncreasingSubarrays(IList<int> nums, int k)
    {
        return false;
    }
    public static TheoryData<int[], int, bool> TestData => new()
    {
        {[2,5,7,8,9,2,3,4,3,1], 3, true},
        {[1,2,3,4,4,4,4,5,6,7], 5, false},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int k, bool expected)
    {
        var actual = HasIncreasingSubarrays(input, k);
        Assert.Equal(expected, actual);
    }
}