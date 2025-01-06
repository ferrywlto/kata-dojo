public class Q2843_CountSymmetricIntegers
{
    public int CountSymmetricIntegers(int low, int high)
    {
        return 0;
    }
    public static TheoryData<int, int, int> TestData => new()
    {
        {1, 100, 9},
        {1200, 1230, 4},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int input1, int input2, int expected)
    {
        var actual = CountSymmetricIntegers(input1, input2);
        Assert.Equal(expected, actual);
    }
}