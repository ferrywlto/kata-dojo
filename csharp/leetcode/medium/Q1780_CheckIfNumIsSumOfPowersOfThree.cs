public class Q1780_CheckIfNumIsSumOfPowersOfThree
{
    int[] powers = [
        3,
        9,
        27,
        81,
        243,
        729,
        2187,
        6561,
        19683,
        59049,
        177147,
        531441,
        1594323,
        4782969,
        14348907,
        43046721,
    ];

    // TC: O(1), it run at most length of powers times
    // SC: O(1)
    public bool CheckPowersOfThree(int n)
    {
        var idx = powers.Length - 1;
        while (idx >= 0)
        {
            while (idx >= 0 && powers[idx] > n) idx--;
            if (idx >= 0)
                n -= powers[idx--];
        }
        return n == 0 || n == 1;
    }
    public static TheoryData<int, bool> TestData => new()
    {
        {12, true},
        {91, true},
        {21, false},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int input, bool expected)
    {
        var actual = CheckPowersOfThree(input);
        Assert.Equal(expected, actual);
    }
}
