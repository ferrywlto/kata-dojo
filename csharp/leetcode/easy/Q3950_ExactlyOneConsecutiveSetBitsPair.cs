public class Q3950_ExactlyOneConsecutiveSetBitsPair
{
    // TC: O(n)
    // SC: O(1)
    public bool ConsecutiveSetBits(int n)
    {
        var pairSeen = false;
        var last = -1;

        while (n > 0)
        {
            var bit = n & 1;
            if (last == 1 && bit == 1)
            {
                if (!pairSeen) pairSeen = true;
                else return false;
            }

            last = bit;
            n >>= 1;
        }
        return pairSeen;
    }

    public static TheoryData<int, bool> TestData => new() { { 6, true }, { 5, false } };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int input, bool expected)
    {
        var actual = ConsecutiveSetBits(input);
        Assert.Equal(expected, actual);
    }
}
