public class Q2748_NumOfBeautifulPairs
{
    public int CountBeautifulPairs(int[] nums)
    {
        return 0;
    }
    public static TheoryData<int[], int> TestData => new()
    {
        {[2,5,1,4], 5},
        {[11,21,12], 2},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = CountBeautifulPairs(input);
        Assert.Equal(expected, actual);
    }

}