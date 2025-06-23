public class Q1551_MinOpsToMakeArrayEqual
{
    public int MinOperations(int n)
    {
        var result = 0;

        return result;
    }
    public static TheoryData<int, int> TestData => new()
    {
        {3, 2},
        {6, 9}
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int input, int expected)
    {
        var actual = MinOperations(input);
        Assert.Equal(expected, actual);
    }
}