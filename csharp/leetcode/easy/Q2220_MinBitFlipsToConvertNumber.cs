public class Q2220_MinBitFlipsToConvertNumber
{
    // TC: O(log n), n scale with Max(start, goal)
    // SC: O(1), space used does not scale with input
    public int MinBitFlips(int start, int goal)
    {
        var result = 0;
        while (start > 0 || goal > 0)
        {
            var bitFromStart = start & 1;
            var bitFromEnd = goal & 1;
            if (bitFromStart != bitFromEnd) result++;
            start >>= 1;
            goal >>= 1;
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