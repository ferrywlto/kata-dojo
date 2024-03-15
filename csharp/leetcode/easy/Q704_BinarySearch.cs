
namespace dojo.leetcode;

public class Q704_BinarySearch
{
    public int Search(int[] nums, int target) 
    {
        return -1;    
    }
}

public class Q704_BinarySearchTestData : TestData
{
    protected override List<object[]> Data => 
    [
        [new int[]{-1,0,3,5,9,12}, 9, 4],
        [new int[]{-1,0,3,5,9,12}, 2, -1],
    ];
}

public class Q704_BinarySearchTests
{
    [Theory]
    [ClassData(typeof(Q704_BinarySearchTestData))]
    public void OfficialTestCases(int[] input, int target, int expected)
    {
        var sut = new Q704_BinarySearch();
        var actual = sut.Search(input, target);
        Assert.Equal(expected, actual);
    }
}