class Q231_PowerOfTwo
{
    // TC:O(1), SC:O(1)
    public bool IsPowerOfTwo(int n) 
    {
        return Math.Log2(n) % 1 == 0;
    }

    // Add a loop based bitwise solution for fun
    // Still O(1) as it only runs a constant number of times (32)
    public bool IsPowerOfTwoLoop(int n)
    {
        // invert to positive representation by 2s complement
        // if (n < 0) n = ~n+1;

        // actually just need to return false if less than zero
        if (n < 0) return false;

        for(byte i=0; i<32; i++)
        {
            if (1 << i == n) return true;
        }
        return false;
    }
}

class Q231_PowerOfTwoTestData: TestData
{
    protected override List<object[]> Data => 
    [
        [1, true],
        [2, true],
        [4, true],
        [8, true],
        [16, true],
        [256, true],
        [1024, true],
        [65536, true],
        [3, false],
        [5, false],
        [9, false],
        [-9, false],
        [17, false],
        [101, false],
        [int.MaxValue, false],
        [int.MinValue, false],
    ];
}

public class Q231_PowerOfTwoTests
{
    [Theory]
    [ClassData(typeof(Q231_PowerOfTwoTestData))]
    public void OfficialTestCases(int input, bool expected)
    {
        var sut = new Q231_PowerOfTwo();
        var actual = sut.IsPowerOfTwo(input);
        Assert.Equal(expected, actual);
    }
}