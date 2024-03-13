
namespace dojo.leetcode;

public class Q693_BinaryNumberWithAlternatingBits
{
    // TC: O(n)
    // SC: O(n)
    public bool HasAlternatingBits(int n) 
    {
        var binaryStr = Convert.ToString(n,2);
        Console.WriteLine(binaryStr);
        for(var i=0; i<binaryStr.Length - 1; i++)
        {
            if (binaryStr[i] == binaryStr[i + 1]) return false;
        }
        return true;       
    }    
}

public class Q693_BinaryNumberWithAlternatingBitsTestData : TestData
{
    protected override List<object[]> Data => 
    [
        [5, true],
        [7, false],
        [11, false],
        [int.MaxValue-1, false],
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