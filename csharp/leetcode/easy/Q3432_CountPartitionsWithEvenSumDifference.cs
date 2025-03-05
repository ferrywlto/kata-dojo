public class Q3432_CountPartitionsWithEvenSumDifference
{
    public int CountPartitions(int[] nums)
    {
        return 0;
    }
    public static TheoryData<int[], int> TestData => new()
    {
        {[10,10,3,7,6], 4},
        {[1,2,2], 0},
        {[2,4,6,8], 3},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = CountPartitions(input);
        Assert.Equal(expected, actual);
    }
}