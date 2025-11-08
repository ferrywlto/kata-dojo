public class Q3736_MinMovesToEqualArrayElementsIII
{
    public int MinMoves(int[] nums)
    {
        return 0;
    }
    public static TheoryData<int[], int> TestData => new()
    {
        {[2,1,3], 3},
        {[4,4,5], 2},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] nums, int expected)
    {
        var result = MinMoves(nums);
        Assert.Equal(expected, result);
    }
}
