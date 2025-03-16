public class Q3483_UniqueThreeDigitsEvenNumbers
{
    public int TotalNumbers(int[] digits)
    {
        return 0;
    }
    public static TheoryData<int[], int> TestData => new()
    {
        {[1,2,3,4], 12},
        {[0,2,2], 2},
        {[6,6,6], 1},
        {[1,3,5], 0},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = TotalNumbers(input);
        Assert.Equal(expected, actual);
    }
}