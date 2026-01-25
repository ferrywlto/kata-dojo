public class Q3818_MinPrefixRemovalToMakeArrayStrictlyIncreasing
{
    public int MinimumPrefixLength(int[] nums) {
        return 0;
    }

    public static TheoryData<int[], int> TestData => new ()
    {
        {[1,-1,2,3,3,4,5], 4},
        {[4,3,-2,-5], 3},
        {[1,2,3,4], 0}
    };
    
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = MinimumPrefixLength(input);
        Assert.Equal(expected, actual);
    }
}
