
using Microsoft.VisualBasic;

class Q977_SquaresOfSortedArray
{
    public int[] SortedSquares(int[] nums) {
        return [];    
    }
}

class Q977_SquaresOfSortedArrayTestData : TestData
{
    protected override List<object[]> Data => 
    [
        [new int[]{-4,-1,0,3,10}, new int[] {0,1,9,16,100}],
        [new int[]{-7,-3,2,3,11}, new int[] {4,9,9,49,121}],
    ];
}

public class Q977_SquaresOfSortedArrayTests
{
    [Theory]
    [ClassData(typeof(Q977_SquaresOfSortedArrayTestData))]
    public void OfficialTestCases(int[] input, int[] expected)
    {
        var sut = new Q977_SquaresOfSortedArray();
        var actual = sut.SortedSquares(input);
        Assert.Equal(expected, actual);
    }
}
