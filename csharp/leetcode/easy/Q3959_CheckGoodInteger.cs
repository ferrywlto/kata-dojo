public class Q3959_CheckGoodInteger
{
    public bool CheckGoodInteger(int n)
    {
        return false;
    }

    public static TheoryData<int, bool> TestData => new()
    {
        { 1000, false },
        { 19, true },
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int input, bool expected)
    {
        var actual = CheckGoodInteger(input);
        Assert.Equal(expected, actual);
    }
}
