public class Q2149_RearrangeArrayElementsBySign
{
    public int[] RearrangeArray(int[] nums)
    {
        return [];
    }
    public static TheoryData<int[], int[]> TestData => new()
    {
        {[3,1,-2,-5,2,-4], [3,-2,1,-5,2,-4]},
        {[-1,1], [1,-1]},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int[] expected)
    {
        var actual = RearrangeArray(input);
        Assert.Equal(expected, actual);
    }
}