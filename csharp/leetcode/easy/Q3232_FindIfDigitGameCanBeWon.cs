public class Q3232_FindIfDigitGameCanBeWon
{
    public bool CanAliceWin(int[] nums)
    {
        return false;
    }
    public static TheoryData<int[], bool> TestData => new()
    {
        {[1,2,3,4,10], false},
        {[1,2,3,4,5,14], true},
        {[5,5,5,25], true},
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, bool expected)
    {
        var actual = CanAliceWin(input);
        Assert.Equal(expected, actual);
    }
}