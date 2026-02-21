public class Q3843_FirstElementWithUniqueFrequency
{
    public int FirstUniqueFreq(int[] nums)
    {
        return 0;
    }
    public static TheoryData<int[], int> TestData => new()
    {
        {[20,10,30,30], 30},
        {[20,20,10,30,30,30], 20},
        {[10,10,20,20], -1}
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = FirstUniqueFreq(input);
        Assert.Equal(expected, actual);
    }
}
