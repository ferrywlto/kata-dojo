public class Q3658_GCDofOddAndEvenSums
{
    public int GcdOfOddEvenSums(int n)
    {
        return 0;
    }
    public static TheoryData<int, int> TestData => new()
    {
        {4, 4},
        {5, 5},
        {6, 6},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int input, int expected)
    {
        var actual = GcdOfOddEvenSums(input);
        Assert.Equal(expected, actual);
    }
}
