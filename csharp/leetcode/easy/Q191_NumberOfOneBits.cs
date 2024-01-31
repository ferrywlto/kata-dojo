namespace dojo.leetcode;

public class Q191_NumberOfOneBitsTestData : TestData
{
    // 0b means binary literal
    // U means unsigned integer
    protected override List<object[]> Data => 
    [
        [0b00000000000000000000000000001011U, 3],
        [0b00000000000000000000000010000000U, 1],
        [0b11111111111111111111111111111101U, 31],
    ];
}

public class Q191_NumberOfOneBitsTests(ITestOutputHelper output): BaseTest(output)
{
    [Theory]
    [ClassData(typeof(Q191_NumberOfOneBitsTestData))]
    public void OfficialTestCases(uint input, int expected)
    {
        var sut = new Q191_NumberOfOneBits();
        var actual = sut.HammingWeight(input);
        Assert.Equal(expected, actual);
    }
}

public class Q191_NumberOfOneBits
{
    public int HammingWeight(uint n) 
    {
        var result = 0;
        var bits = 32;
        while (bits > 0)
        {
            if ((n & 1) == 1) 
            {
                result++;
            }
            n >>= 1;
            bits--;
        }
        return result;
    }
}