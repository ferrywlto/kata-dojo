public class Q2855_MinRightShiftsToSortArray
{
    public int MinimumRightShifts(IList<int> nums)
    {
        return 0;
    }
    public static TheoryData<int[], int> TestData => new()
    {
        {[3,4,5,1,2], 2},
        {[1,3,5], 0},
        {[2,1,4], -1},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = MinimumRightShifts(input);
        Assert.Equal(expected, actual);
    }
}