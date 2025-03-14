public class Q3411_MaxSubarrayWithEqualProducts
{
    public int MaxLength(int[] nums)
    {
        return 0;   
    }    
    public static TheoryData<int[], int> TestData => new ()
    {
        {[1,2,1,2,1,1,1], 5},
        {[2,3,4,5,6], 3},
        {[1,2,3,1,4,5,1], 5},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = MaxLength(input);
        Assert.Equal(expected, actual);
    }
}