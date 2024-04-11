
namespace dojo.leetcode;

public class Q867_TransposeMatrix
{
    public int[][] Transpose(int[][] matrix) 
    {
        return [];    
    }
}

public class Q867_TransposeMatrixTestData : TestData
{
    protected override List<object[]> Data => 
    [
        [
            new int[][] {
                [1,2,3],
                [4,5,6],
                [7,8,9],
            }, 
            new int[][] {
                [1,4,7],
                [2,5,8],
                [3,6,9],
            }, 
        ],
        [
            new int[][] {
                [1,2,3],
                [4,5,6],
            },
            new int[][] {
                [1,4],
                [2,5],
                [3,6],
            },
        ],
    ];
}

public class Q867_TransposeMatrixTests
{
    [Theory]
    [ClassData(typeof(Q867_TransposeMatrixTestData))]
    public void OfficialTestCases(int[][] input, int[][] expected)
    {
        var sut = new Q867_TransposeMatrix();
        var actual = sut.Transpose(input);
        Assert.Equal(expected, actual);
    }
}