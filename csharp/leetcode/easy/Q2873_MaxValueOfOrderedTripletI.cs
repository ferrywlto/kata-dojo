public class Q2873_MaxValueOfOrderedTripletI
{
    public long MaximumTripletValue(int[] nums)
    {
        return 0;
    }
    public static TheoryData<int[], long> TestData => new()
    {
        {[12,6,1,2,7], 77},
        {[1,10,3,4,19], 133},
        {[1,2,3], 0},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, long expected)
    {
        var actual = MaximumTripletValue(input);
        Assert.Equal(expected, actual);
    }
}