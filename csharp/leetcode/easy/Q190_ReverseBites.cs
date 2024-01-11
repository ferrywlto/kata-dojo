
namespace dojo.leetcode;

public class Q190_ReverseBitsTestData : TestData
{
    protected override List<object[]> Data => 
    [
        [43261596, 964176192],
        [4294967293, 3221225471],
    ];
}

public class Q190_ReverseBitsTests(ITestOutputHelper output) : TestBase(output)
{
    [Theory]
    [ClassData(typeof(Q190_ReverseBitsTestData))]
    public void OfficialTestCases(int input, int expected)
    {
        var solution = new Q190_ReverseBits();
        Assert.Equal(input, expected);
    }
}

public class Q190_ReverseBits
{
    public uint reverseBits(uint n) 
    {
        return 0;    
    }
}

