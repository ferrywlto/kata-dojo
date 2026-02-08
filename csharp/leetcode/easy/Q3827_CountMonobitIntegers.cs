public class Q3827_CountMonobitIntegers
{
    public int CountMonobit(int n)
    {
        return 0;
    }
    public static TheoryData<int, int> TestData => new()
    {
        {1, 2},
        {4, 3},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int input, int expected)
    {
        var actual = CountMonobit(input);
        Assert.Equal(expected, actual);
    }
}
