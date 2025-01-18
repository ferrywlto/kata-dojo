public class Q2908_MinSumOfMountainTripletsI
{
    public int MinimumSum(int[] nums)
    {
        return 0;
    }
    public static TheoryData<int[], int> TestData => new()
    {
        {[8,6,1,5,3], 9},
        {[5,4,8,7,10,2], 13},
        {[5,4,8,7,10,2], 13},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = MinimumSum(input);
        Assert.Equal(expected, actual);
    }
}