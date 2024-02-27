
namespace dojo.leetcode;

public class Q598_RangeAdditionII
{
    public int MaxCount(int m, int n, int[][] ops) 
    {
        return 0;    
    }
}

public class Q598_RangeAdditionIITestData : TestData
{
    protected override List<object[]> Data => 
    [
        [3, 3, Array.Empty<int[][]>(), 4],
        [3, 3, new int[][]{[2,2], [3,3]}, 4],
        [3, 3, new int[][]{[2,2], [3,3], [3,3], [3,3], [2,2], [3,3], [3,3], [3,3], [2,2], [3,3], [3,3], [3,3]}, 4],

    ];
}

public class Q598_RangeAdditionIITests
{
    [Theory]
    [ClassData(typeof(Q598_RangeAdditionIITestData))]
    public void OfficialTestCases(int m, int n, int[][] ops, int expected)
    {
        var sut = new Q598_RangeAdditionII();
        var actual = sut.MaxCount(m, n, ops);
        Assert.Equal(expected, actual);
    }
}