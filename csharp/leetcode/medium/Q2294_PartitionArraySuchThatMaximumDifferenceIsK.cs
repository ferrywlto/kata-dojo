public class Q2294_PartitionArraySuchThatMaximumDifferenceIsK
{
    public int PartitionArray(int[] nums, int k)
    {
        return 0;
    }
    public static TheoryData<int[], int, int> TestData => new()
    {
        {[3,6,1,2,5], 2, 2},
        {[1,2,3], 1, 2},
        {[2,2,4,5], 0, 3},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int k, int expected)
    {
        var actual = PartitionArray(input, k);
        Assert.Equal(expected, actual);
    }
}