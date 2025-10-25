public class Q3712_SumElementsWithFrequencyDivisibleByK
{
    public int SumDivisibleByK(int[] nums, int k)
    {
        return 0;
    }
    public static TheoryData<int[], int, int> TestData => new()
    {
        { [1,2,2,3,3,3,3,4], 2, 16 },
        { [1,2,3,4,5], 2, 0 },
        { [4,4,4,1,2,3], 3, 12 },
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] nums, int k, int expected)
    {
        var result = SumDivisibleByK(nums, k);
        Assert.Equal(expected, result);
    }
}
