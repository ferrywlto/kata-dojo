public class Q3536_MaxProductOfTwoDigits
{
    public int MaxProduct(int n)
    {
        return 0;
    }
    public static TheoryData<int, int> TestData => new()
    {
        {31, 3},
        {22, 4},
        {124, 8},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int input, int expected)
    {
        var actual = MaxProduct(input);
        Assert.Equal(expected, actual);
    }
}