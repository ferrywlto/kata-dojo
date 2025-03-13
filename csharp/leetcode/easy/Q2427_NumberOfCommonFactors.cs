public class Q2427_NumberOfCommonFactors
{
    public int CommonFactors(int a, int b)
    {
        return 0;
    }
    public static TheoryData<int, int, int> TestData => new()
    {
        {12, 6, 4},
        {25, 30, 2},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int input1, int input2, int expected)
    {
        var actual = CommonFactors(input1, input2);
        Assert.Equal(expected, actual);
    }
}