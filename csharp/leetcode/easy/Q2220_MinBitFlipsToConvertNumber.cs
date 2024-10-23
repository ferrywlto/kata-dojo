public class Q2220_MinBitFlipsToConvertNumber
{
    // TC: O(log n), n scale with Max(start, goal)
    // SC: O(1), space used does not scale with input
    public int MinBitFlips(int start, int goal)
    {
        var xor = start ^ goal;
        var result = 0;

        while(xor > 0)
        {
            // if bit is different it will be 1
            result += xor & 1;
            xor >>= 1;
        }
        return result;
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