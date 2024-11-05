public class Q2335_MinAmountTimeToFillCups
{
    public int FillCups(int[] amount)
    {
        return 0;
    }
    public static List<object[]> TestData =>
    [
        [new int[]{1,4,2}, 4],
        [new int[]{5,4,4}, 7],
        [new int[]{5,0,0}, 5],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = FillCups(input);
        Assert.Equal(expected, actual);
    }
}