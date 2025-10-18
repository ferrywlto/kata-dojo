public class Q3678_SmallestAbsentPositiveGreaterThanAverage
{
    public int SmallestAbsent(int[] nums)
    {
        return 0;
    }
    public static TheoryData<int[], int> TestData => new ()
    {
        {[3,5], 6},
        {[-1,1,2], 3},
        {[4,-1], 2},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] nums, int expected)
    {
        var actual = SmallestAbsent(nums);
        Assert.Equal(expected, actual);
    }
}
