public class Q3452_SumOfGoodNumbers
{
    public int SumOfGoodNumbers(int[] nums, int k)
    {
        return 0;
    }
    public static TheoryData<int[], int, int> TestData => new()
    {
        {[1,3,2,1,5,4], 2, 12},
        {[2,1], 1, 2},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int k, int expected)
    {
        var actual = SumOfGoodNumbers(input, k);
        Assert.Equal(expected, actual);
    }
}