public class Q3360_StoneRemovealGame
{
    public bool CanAliceWin(int n)
    {
        return false;
    }
    public static TheoryData<int, bool> TestData => new()
    {
        {12, true},
        {1, false}
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int input, bool expected)
    {
        var actual = CanAliceWin(input);
        Assert.Equal(expected, actual);
    }
}