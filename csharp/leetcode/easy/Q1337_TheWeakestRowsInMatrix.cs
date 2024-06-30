class Q1337_TheWeakestRowsInMatrix
{
    public int[] KWeakestRows(int[][] mat, int k)
    {
        return [];
    }
}
class Q1337_TheWeakestRowsInMatrixTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [
            new int[][]
            {
                [1,1,0,0,0],
                [1,1,1,1,0],
                [1,0,0,0,0],
                [1,1,0,0,0],
                [1,1,1,1,1],
            }, 3,
            new int[] {2,0,3}
        ],
        [
            new int[][]
            {
                [1,0,0,0],
                [1,1,1,1],
                [1,0,0,0],
                [1,0,0,0],
            }, 2,
            new int[] {0,2}
        ]
    ];
}
public class Q1337_TheWeakestRowsInMatrixTests
{
    [Theory]
    [ClassData(typeof(Q1337_TheWeakestRowsInMatrixTestData))]
    public void OfficialTestCases(int[][] input, int k, int[] expected)
    {
        var sut = new Q1337_TheWeakestRowsInMatrix();
        var actual = sut.KWeakestRows(input, k);
        Assert.Equal(expected, actual);
    }
}