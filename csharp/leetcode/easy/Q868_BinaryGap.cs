
namespace dojo.leetcode;

public class Q868_BinaryGap
{
    // TC: O(n), n is number of bits of input
    // SC: O(1), no extra memory used
    public int BinaryGap(int n) 
    {
        var maxDistance = 0;
        var initialized = false;
        var numZeros = 0;

        while(n > 0)
        {
            if ((n & 1) == 1)
            {
                if(numZeros + 1 > maxDistance)
                {
                    if (initialized) maxDistance = numZeros + 1;
                    else initialized = true;
                }
                numZeros = 0;
            }
            else numZeros++;

            n >>= 1;
        }
        return maxDistance;    
    }
}

public class Q868_BinaryGapTestData : TestData
{
    protected override List<object[]> Data => 
    [
        [22,2],
        [8,0],
        [5,2],
    ];
}

public class Q868_BinaryGapTests
{
    [Theory]
    [ClassData(typeof(Q868_BinaryGapTestData))]
    public void OfficialTestCases(int input, int expected)
    {
        var sut = new Q868_BinaryGap();
        var actual = sut.BinaryGap(input);
        Assert.Equal(expected, actual);
    }
}