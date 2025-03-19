public class Q3200_MaxHeightOfTriangle
{
    public int MaxHeightOfTriangle(int red, int blue)
    {
        return 0;
    }
    public static TheoryData<int, int, int> TestData => new()
    {
        {2, 4, 3},
        {2, 1, 2},
        {1, 1, 1},
        {10, 1, 2},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int input1, int input2, int expected)
    {
        var actual = MaxHeightOfTriangle(input1, input2);
        Assert.Equal(expected, actual);
    }
}