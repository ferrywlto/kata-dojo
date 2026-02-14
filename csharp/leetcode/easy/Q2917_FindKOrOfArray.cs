public class Q2917_FindKOrOfArray
{
    // TC: O(n), n sacle with length of nums
    // SC: O(1), space used is constant
    public int FindKOr(int[] nums, int k)
    {
        var bits = new int[32];
        var kOrBits = new int[32];
        foreach (var num in nums)
        {
            var n = num;
            var idx = 31;
            while (n > 0)
            {
                if (kOrBits[idx] == 0 && (n & 1) == 1)
                {
                    if (++bits[idx] >= k) kOrBits[idx] = 1;
                }
                n >>= 1;
                idx--;
            }
        }
        var result = 0;
        for (var j = 31; j >= 0; j--)
        {
            if (kOrBits[j] == 1)
            {
                result |= 1 << (31 - j);
            }
        }
        return result;
    }
    public static TheoryData<int[], int, int> TestData => new()
    {
        {[7,12,9,8,9,15], 4, 9},
        {[2,12,1,11,4,5], 6, 0},
        {[10,8,5,9,11,6,8], 1, 15},
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int k, int expected)
    {
        var actual = FindKOr(input, k);
        Assert.Equal(expected, actual);
    }
}
