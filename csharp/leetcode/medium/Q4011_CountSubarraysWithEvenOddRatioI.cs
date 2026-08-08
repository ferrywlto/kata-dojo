public class Q4011_CountSubarraysWithEvenOddRatioI
{
    public int CountRatioSubarrays(int[] nums, int a, int b)
    {
        return 0;
    }

    public static TheoryData<int[], int, int, int> TestData => new()
    {
        {[1,2,1,2], 3, 2, 7},
        {[2,2,1], 2, 1, 3},
        {[2,2,2], 1, 1, 0}
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int a, int b, int expected)
    {
        var actual = CountRatioSubarrays(input, a, b);
        Assert.Equal(expected, actual);
    }
}
