public class Q3300_MinElementAfterReplacementWithDigitSum
{
    public int MinElement(int[] nums)
    {
        return 0;
    }
    public static TheoryData<int[], int> TestData => new()
    {
        {[10,12,13,14], 1},
        {[1,2,3,4], 1},
        {[999,19,199], 10},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = MinElement(input);
        Assert.Equal(expected, actual);
    }
}