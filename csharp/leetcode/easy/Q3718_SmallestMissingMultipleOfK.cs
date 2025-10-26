public class Q3718_SmallestMissingMultipleOfK
{
    public int MissingMultiple(int[] nums, int k)
    {
        return 0;
    }

    public static TheoryData<int[], int, int> TestData => new()
    {
        {[8,2,3,4,6], 2, 10},
        {[1,4,7,10,15], 5, 5},
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] nums, int k, int expected)
    {
        var result = MissingMultiple(nums, k);
        Assert.Equal(expected, result);
    }
}
