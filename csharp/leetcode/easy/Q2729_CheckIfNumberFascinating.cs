public class Q2729_CheckIfNumberFascinating
{
    public bool IsFascinating(int n)
    {
        return false;
    }
    public static TheoryData<int, bool> TestData => new()
    {
        {192, true},
        {100, false},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int input, bool expected)
    {
        var actual = IsFascinating(input);
        Assert.Equal(expected, actual);

    }
}