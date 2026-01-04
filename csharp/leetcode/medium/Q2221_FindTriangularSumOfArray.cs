public class Q2221_FindTriangularSumOfArray
{
    public int TriangularSum(int[] nums)
    {
        return 0;
    }
    public static TheoryData<int[], int> TestData => new()
    {
        {[1,2,3,4,5], 8},
        {[5], 5},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = TriangularSum(input);
        Assert.Equal(expected, actual);
    }
}
