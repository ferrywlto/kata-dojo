
namespace dojo.leetcode;

public class Q693_BinaryNumberWithAlternatingBits
{
    public bool HasAlternatingBits(int n) 
    {
        return false;       
    }    
}

public class Q693_BinaryNumberWithAlternatingBitsTestData : TestData
{
    protected override List<object[]> Data => 
    [
        [5, true],
        [7, false],
        [11, false],
    ];
}

public class Q693_BinaryNumberWithAlternatingBitsTests
{
    [Theory]
    [ClassData(typeof(Q693_BinaryNumberWithAlternatingBitsTestData))]
    public void OfficialTestCases(int input, bool expected)
    {
        var sut = new Q693_BinaryNumberWithAlternatingBits();
        var actual = sut.HasAlternatingBits(input);
        Assert.Equal(expected, actual);
    }
}