public class Q2220_MinBitFlipsToConvertNumber
{
    public int MinBitFlips(int start, int goal)
    {
        return 0;
    }
    public static List<object[]> TestData =>
    [
        [10, 7, 3],
        [3, 4, 3],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int input1, int input2, int expected)
    {
        var actual = MinBitFlips(input1, input2);
        Assert.Equal(expected, actual);
    }
}