public class Q2595_NumOfEvenAndOddBits
{
    public int[] EvenOddBit(int n)
    {
        return [];
    }
    public static List<object[]> TestData =>
    [
        [50, new int[] { 1, 2 }],
        [2, new int[] { 0, 1 }],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int input, int[] expected)
    {
        var actual = EvenOddBit(input);
        Assert.Equal(expected, actual);
    }
}