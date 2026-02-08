public class Q3828_FinalElementAfterSubarrayDeletions
{
    public int FinalElement(int[] nums)
    {
        return 0;
    }

    public static TheoryData<int[], int> TestData => new()
    {
        {[1,5,2], 2},
        {[3,7], 7},
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = FinalElement(input);
        Assert.Equal(expected, actual);
    }
}
