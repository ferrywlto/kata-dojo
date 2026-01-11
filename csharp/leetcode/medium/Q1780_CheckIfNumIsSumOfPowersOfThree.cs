public class Q1780_CheckIfNumIsSumOfPowersOfThree
{
    public bool CheckPowersOfThree(int n)
    {
        return false;
    }
    public static TheoryData<int, bool> TestData => new()
    {
        {12, true},
        {91, true},
        {21, false},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int input, bool expected)
    {
        var actual = CheckPowersOfThree(input);
        Assert.Equal(expected, actual);
    }
}
