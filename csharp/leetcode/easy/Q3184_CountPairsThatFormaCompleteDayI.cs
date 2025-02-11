public class Q3184_CountPairsThatFormaCompleteDayI
{
    public int CountCompleteDayPairs(int[] hours)
    {
        return 0;
    }
    public static TheoryData<int[], int> TestData => new()
    {
        {[12,12,30,24,24], 2},
        {[72,48,24,3], 3},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = CountCompleteDayPairs(input);
        Assert.Equal(expected, actual);
    }
}