public class Q2733_NeitherMinOrMax
{
    public int FindNonMinOrMax(int[] nums)
    {
        return 0;
    }
    public static TheoryData<int[], int> TestData => new()
    {
        {[3,2,1,4], 2},
        {[1,2], -1},
        {[2,1,3], 2},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = FindNonMinOrMax(input);
        Assert.Equal(expected, actual);
    }
}