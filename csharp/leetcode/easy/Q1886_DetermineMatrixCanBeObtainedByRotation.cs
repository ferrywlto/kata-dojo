class Q1886_DetermineMatrixCanBeObtainedByRotation
{
    // TC: O(n^2), where n is dimension of mat
    // SC: O(1), space used does not scale with dimension of mat
    public bool FindRotation(int[][] mat, int[][] target)
    {
        for (var i = 0; i < 4; i++)
        {
            if (!Equals(mat, target))
            {
                Rotate(mat);
            }
            else return true;
        }
        return false;
    }
    public void Rotate(int[][] mat)
    {
        int n = mat.Length; // Get the dimension of the matrix

        // Loop through each layer
        for (int i = 0; i < n / 2; i++)
        {
            Console.WriteLine($"======");
            // Loop through each element in the current layer
            for (int j = i; j < n - i - 1; j++)
            {
                Console.WriteLine($"------");

                // Save the top element
                int temp = mat[i][j];
                Console.WriteLine($"[{i},{j}] <= [{n - j - 1},{i}]");
                // Move left element to top
                mat[i][j] = mat[n - j - 1][i];

                Console.WriteLine($"[{n - j - 1},{i}] <= [{n - i - 1},{n - j - 1}]");
                // Move bottom element to left
                mat[n - j - 1][i] = mat[n - i - 1][n - j - 1];

                Console.WriteLine($"[{n - i - 1},{n - j - 1}] <= [{j},{n - i - 1}]");
                // Move right element to bottom
                mat[n - i - 1][n - j - 1] = mat[j][n - i - 1];

                Console.WriteLine($"[{j},{n - i - 1}] <= [{i},{j}]");
                // Move top element to right
                mat[j][n - i - 1] = temp;
            }
        }
    }
    public bool Equals(int[][] source, int[][] target)
    {
        for (var i = 0; i < source.Length; i++)
        {
            for (var j = 0; j < source[i].Length; j++)
            {
                if (source[i][j] != target[i][j]) return false;
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