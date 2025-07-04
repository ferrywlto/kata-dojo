public class Q2698_FindPunishmentNumberOfInteger
{
    public int PunishmentNumber(int n)
    {
        return 0;
    }
    public static TheoryData<int, int> TestData => new()
    {
        {10, 182},
        {37, 1478},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int input, int expected)
    {
        var actual = PunishmentNumber(input);
        Assert.Equal(expected, actual);
    }
}