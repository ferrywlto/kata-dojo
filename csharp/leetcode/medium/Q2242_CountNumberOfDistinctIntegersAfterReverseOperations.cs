public class Q2242_CountNumberOfDistinctIntegersAfterReverseOperations
{
    public int CountDistinctIntegers(int[] nums)
    {
        return 0;
    }
    public static TheoryData<int[], int> TestData => new()
    {
        {[1,13,10,12,31], 6},
        {[2,2,2], 6},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = CountDistinctIntegers(input);
        Assert.Equal(expected, actual);
    }    
}
