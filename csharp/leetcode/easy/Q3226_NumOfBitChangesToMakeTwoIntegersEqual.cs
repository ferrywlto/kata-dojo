public class Q3226_NumOfBitChangesToMakeTwoIntegersEqual
{
    // TC: O(1), since both n and k is 32 bits integer, it cannot exceed more than 32 operations, furthermore the question constraints stated both n & k is < 10^6 so the time is constant
    // SC: O(1), space used does not scale with input
    public int MinChanges(int n, int k)
    {
        var result = 0;
        while (n > 0 || k > 0)
        {
            var digit_n = n & 1;
            var digit_k = k & 1;

            if (digit_n == 0 && digit_k == 1) return -1;
            else if (digit_n == 1 && digit_k == 0) result++;

            n >>= 1;
            k >>= 1;
        }
        return result;
    }
    public static TheoryData<int, int, int> TestData => new()
    {
        {13, 4, 2},
        {21, 21, 0},
        {14, 13, -1},
        {11, 56, -1},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int input1, int input2, int expected)
    {
        var actual = MinChanges(input1, input2);
        Assert.Equal(expected, actual);
    }
}
