
namespace dojo.leetcode;

public class Q868_BinaryGap
{
    public int BinaryGap(int n) 
    {
        return 0;    
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