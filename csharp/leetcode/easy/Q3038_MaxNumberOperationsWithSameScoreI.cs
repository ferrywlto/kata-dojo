public class Q3038_MaxNumberOperationsWithSameScoreI
{
    public int MaxOperations(int[] nums)
    {
        return 0;
    }
    public static TheoryData<int[], int> TestData => new()
    {
        {[3,2,1,4,5], 2},
        {[1,5,3,3,4,1,3,2,2,3], 2},
        {[5,3], 1},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = MaxOperations(input);
        Assert.Equal(expected, actual);
    }
}