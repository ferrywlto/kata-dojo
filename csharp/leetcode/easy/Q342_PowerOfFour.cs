class Q342_PowerOfFour
{
    // Max power of 4 of a Int32 is 1073741824 = 4^15 = 2^2^15 = 2^30
    // Power of 2 that is not power of 4: 2,8,32 => 2^[1,3,5,...] odd expoent
    public bool IsPowerOfFour(int n)
    {
        if (n <= 0) return false;
        // Check if n is a power of 4
        if (1073741824 % n != 0) return false;
        // Check if the exponent of 2 is odd
        int logBase2 = (int)(Math.Log(n) / Math.Log(2));
        return logBase2 % 2 == 0;
    }

    // bitwise operation explained:
    // Check power of two
    // n & (n - 1) : if n is power of two, must be one 1 and all 0s, e.g. 8 (1000)
    // such number - 1 will make all the zeros right of 1 become 1, e.g. 7 (0111)
    // Bitwise AND will always become all zero (0000)

    // Check power of four
    // Since 5 is 0101, 0x55555555 (eight 5 => 32 bits)
    // resulting 01010101010101010101010101010101
    // the rightmost is expoent 0, 2 is exponent 1 (at 2nd rightmost), 8 is expoent 3 (at 4th rightmost)... and so on
    // those with 1 is the power of four, 2^0, 2^2, 2^4, 2^6
    // if 0x55555555 AND n != all zero, that means at least hit any exponent that is the power of four.
    public bool IsPowerOfFour_1Line(int n)
    {
        return n > 0 && (n & (n - 1)) == 0 && (n & 0x55555555) != 0;
    }
}

class Q342_PowerOfFourTestData: TestData
{
    protected override List<object[]> Data => 
    [
        [16, true],
        [5, false],
        [1, true],
        [2, false],
        [8, false],
        [32, false],
    ];
}

public class Q342_PowerOfFourTests
{
    [Theory]
    [ClassData(typeof(Q342_PowerOfFourTestData))]
    public void OfficialTestCases(int input, bool expected)
    {
        var sut = new Q342_PowerOfFour();
        var actual = sut.IsPowerOfFour(input);
        Assert.Equal(expected, actual);
    }
}