public class Q2275_LargestCombinationWithBitwiseAndGreaterThanZero
{
    // TC: O(n), n scale with length of candidates
    // SC: O(1), space used does not scale with input
    /*
     The technique is to count the bits position of each number, 
     those have the same bit position set to 1 can only result > 1 when bitwise AND together.
     The largest one means the most number of numbers have this bits == 1
    */
    public int LargestCombination(int[] candidates)
    {
        // Constraint candidates[i] <= 10^7 = 10000000
        // 2^24 = 16777216 is the minimum that larger than 10^7
        const int maxBits = 24;
        var onesCount = new int[maxBits];
        var max = 0;
        var len = candidates.Length;
        for (var i = 0; i < len; i++)
        {
            var tmp = candidates[i];
            var bitCount = 0;
            while (bitCount < 24)
            {
                if ((tmp & 1) == 1)
                {
                    onesCount[bitCount]++;
                    if (onesCount[bitCount] > max)
                    {
                        max = onesCount[bitCount];
                    }
                }
                tmp >>= 1;
                bitCount++;
            }
        }
        return max;
    }

    public static TheoryData<int[], int> TestData => new()
    {
        {[16,17,71,62,12,24,14], 4},
        {[8,8], 2},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = LargestCombination(input);
        Assert.Equal(expected, actual);
    }
}
