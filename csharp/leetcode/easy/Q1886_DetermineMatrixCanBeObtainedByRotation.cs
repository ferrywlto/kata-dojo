class Q1886_DetermineMatrixCanBeObtainedByRotation
{
    // TC: O(n^2), where n is dimension of mat
    // SC: O(n^2), where n scale with dimension of mat for Rotate
    public bool FindRotation(int[][] mat, int[][] target)
    {
        for(var i=0; i<4; i++)
        {
            if (!Equals(mat, target))
            {
                mat = Rotate(mat);
            }
            else return true;
        }
        return false;
    }
    public int[][] Rotate(int[][] source)
    {
        var temp = new int[source.Length][];
        for (var i = 0; i<temp.Length; i++)
        {
            temp[i] = new int[source.Length];
        }
        for(var i=0; i<source.Length; i++)
        {
            for(var j=0; j<source[i].Length; j++)
            {
                temp[j][^(i + 1)] = source[i][j]; 
            }
        }
        return temp;
    }
    public bool Equals(int[][] source, int[][] target)
    {
        for(var i=0; i<source.Length; i++)
        {
            for(var j=0; j<source[i].Length; j++)
            {
                if(source[i][j] != target[i][j]) return false; 
            }
        }
        return true;
    }
}
class Q1886_DetermineMatrixCanBeObtainedByRotationTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [
            new int[][]
            {
                [0,1],
                [1,0],
            },
            new int[][]
            {
                [1,0],
                [0,1],
            },
            true
        ],
        [
            new int[][]
            {
                [0,1],
                [1,1],
            },
            new int[][]
            {
                [1,0],
                [0,1],
            },
            false
        ],
        [
            new int[][]
            {
                [0,0,0],
                [0,1,0],
                [1,1,1],
            },
            new int[][]
            {
                [1,1,1],
                [0,1,0],
                [0,0,0],
            },
            true
        ]
    ];
}
public class Q1886_DetermineMatrixCanBeObtainedByRotationTests
{
    [Theory]
    [ClassData(typeof(Q1886_DetermineMatrixCanBeObtainedByRotationTestData))]
    public void OfficialTestCases(int[][] input, int[][] target, bool expected)
    {
        var sut = new Q1886_DetermineMatrixCanBeObtainedByRotation();
        var actual = sut.FindRotation(input, target);
        Assert.Equal(expected, actual);
    }
}