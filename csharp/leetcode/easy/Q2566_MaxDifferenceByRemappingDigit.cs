public class Q2566_MaxDifferenceByRemappingDigit
{
    public int MinMaxDifference(int num)
    {
        return 0;
    }
    public static List<object[]> TestData =>
    [
        [11891, 99009],
        [90, 99],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int input, int expected)
    {
        var actual = MinMaxDifference(input);
        Assert.Equal(expected, actual);
    }
}