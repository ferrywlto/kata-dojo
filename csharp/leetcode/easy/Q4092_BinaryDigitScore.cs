public class Q4092_BinaryDigitScore
{
    // TC: O(n)
    // SC: O(1)
    public int CalculateScore(int a, int b)
    {
        int s1 = GetSetBits(a), s2 = GetSetBits(b);
        return (s1 >= s2) ? s1 * s2 : s2 / s1;
    }

    private int GetSetBits(int input)
    {
        var count = 0;
        while (input > 0)
        {
            if ((input & 1) == 1) count++;
            input >>= 1;
        }

        return count;
    }

    public static TheoryData<int, int, int> TestData => new()
    {
        { 14, 6, 6 },
        { 5, 15, 2 },
        { 10, 12, 4 },
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int a, int b, int expected)
    {
        var actual = CalculateScore(a, b);
        Assert.Equal(expected, actual);
    }
}
