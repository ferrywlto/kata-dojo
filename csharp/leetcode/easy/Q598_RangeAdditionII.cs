class Q598_RangeAdditionII
{
    // TC: O(n)
    // SC: O(1)
    public int MaxCount(int m, int n, int[][] ops) 
    {
        if (ops.Length == 0) return m * n;

        // only need to take care of the smallest 
        var minX = m;
        var minY = n;
        foreach(var op in ops)
        {
            if (op[0] < minX) minX = op[0];
            if (op[1] < minY) minY = op[1];
        }
        return minX * minY;
    }
}

class Q598_RangeAdditionIITestData : TestData
{
    protected override List<object[]> Data => 
    [
        [3, 3, Array.Empty<int[][]>(), 9],
        [3, 3, new int[][]{[2,2], [3,3]}, 4],
        [3, 3, new int[][]{[2,2], [3,3], [3,3], [3,3], [2,2], [3,3], [3,3], [3,3], [2,2], [3,3], [3,3], [3,3]}, 4],
        [18, 3, new int[][]{[16,1],[14,3],[14,2],[4,1],[10,1],[11,1],[8,3],[16,2],[13,1],[8,3],[2,2],[9,1],[3,1],[2,2],[6,3]}, 2],

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