
namespace dojo.leetcode;

public class Q766_ToeplitzMatrix
{
    public bool IsToeplitzMatrix(int[][] matrix)
    {
        return false;
    }
}

public class Q766_ToeplitzMatrixTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [
            new int[][]
            {
                [1, 2, 3, 4],
                [5, 1, 2, 3],
                [9, 5, 1, 2],
            },
            true
        ],
        [
            new int[][]
            {
                [1, 2],
                [2, 2],
            },
            false
        ]
    ];
}

public class Q766_ToeplitzMatrixTests
{
    [Theory]
    [ClassData(typeof(Q766_ToeplitzMatrixTestData))]
    public void OfficialTestCases(int[][] input, bool expected)
    {
        var sut = new Q766_ToeplitzMatrix();
        var actual = sut.IsToeplitzMatrix(input);
        Assert.Equal(expected, actual);
    }
}
