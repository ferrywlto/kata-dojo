public class Q2595_NumOfEvenAndOddBits
{
    // TC: O(n), n scale with bits in n
    // SC: O(1), space used does not sacle with input, except for holding result
    public int[] EvenOddBit(int n)
    {
        var bitIdx = 0;
        var oddBitIsOne = 0;
        var evenBitIsOne = 0;
        while (n > 0)
        {
            if ((n & 1) == 1)
            {
                if (bitIdx % 2 == 0) evenBitIsOne++;
                else oddBitIsOne++;
            }
            n >>= 1;
            bitIdx++;
        }
        return [evenBitIsOne, oddBitIsOne];
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
