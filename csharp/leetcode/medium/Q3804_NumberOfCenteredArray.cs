public class Q3804_NumberOfCanteredArray
{
    public int CenteredSubarrays(int[] nums)
    {
        return 0;
    }
    public static TheoryData<int[], int> TestData => new()
    {
        {[-1,1,0], 5},
        {[2,-3], 1},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = CenteredSubarrays(input);
        Assert.Equal(expected, actual);
    }
}
