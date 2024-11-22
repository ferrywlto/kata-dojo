public class Q2485_FindPivotInteger
{
    public int PivotInteger(int n)
    {
        return 0;
    }
    public static List<object[]> TestData =>
    [
        [8,6],
        [1,1],
        [4,-1],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int input, int expected)
    {
        var actual = PivotInteger(input);
        Assert.Equal(expected, actual);
    }
}