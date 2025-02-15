public class Q3226_NumOfBitChangesToMakeTwoIntegersEqual
{
    public int MinChanges(int n, int k)
    {
        return 0;
    }
    public static TheoryData<int, int, int> TestData => new()
    {
        {13, 4, 2},
        {21, 21, 0},
        {14, 13, -1},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int input1, int input2, int expected)
    {
        var actual = MinChanges(input1, input2);
        Assert.Equal(expected, actual);
    }
}
