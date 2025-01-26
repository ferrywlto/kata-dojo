public class Q3005_CountElementsWithMaxFrequency
{
    public int MaxFrequencyElements(int[] nums)
    {
        return 0;
    }
    public static TheoryData<int[], int> TestData => new()
    {
        {[1,2,2,3,1,4], 4},
        {[1,2,3,4,5], 5},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = MaxFrequencyElements(input);
        Assert.Equal(expected, actual);
    }
}