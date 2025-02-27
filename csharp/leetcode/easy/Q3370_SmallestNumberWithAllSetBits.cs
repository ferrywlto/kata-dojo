public class Q3370_SmallestNumberWithAllSetBits
{
    public int SmallestNumber(int n)
    {
        return 0;
    }
    public static TheoryData<int, int> TestData => new()
    {
        {5, 7},
        {10, 15},
        {3, 3},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int input, int expected)
    {
        var actual = SmallestNumber(input);
        Assert.Equal(expected, actual);
    }
}