public class Q48_RotateImage
{
    // TC: O(n^2), n scale with length of matrix
    // SC: O(1), only whole a row or a column
    private void Rotate(int[][] matrix)
    {
        // Time: O(n^2) for transpose + reverse; Space: O(1) extra.
        // var queue = new Queue<int>();
        // Rotate(matrix, 0, 0, matrix.Length, queue);

        TransposeInPlace(matrix);
        ReverseRows(matrix);
    }
    private void TransposeInPlace(int[][] input)
    {
        // Time: O(n^2) upper-triangle swaps; Space: O(1).
        var n = input.Length;
        for (var row = 0; row < n; row++)
        {
            for (var col = row + 1; col < n; col++)
            {
                (input[row][col], input[col][row]) = (input[col][row], input[row][col]);
            }
        }
    }
    private void ReverseRows(int[][] input)
    {
        // Time: O(n^2) row swaps; Space: O(1).
        for (var row = 0; row < input.Length; row++)
        {
            for (var col = 0; col < input.Length / 2; col++)
            {
                (input[row][^(col + 1)], input[row][col]) = (input[row][col], input[row][^(col + 1)]);
            }
        }
    }

    private void Rotate(int[][] input, int rowStartIdx, int colStartIdx, int size, Queue<int> queue)
    {
        // Time: O(n^2) total across layers; Space: O(n) queue + O(n) recursion depth.
        if (size < 2) return;

        queue.Clear();

        var colEndIdx = colStartIdx + size - 1;
        var rowEndIdx = rowStartIdx + size - 1;

        // top
        for (var col = colStartIdx; col < colEndIdx; col++)
        {
            queue.Enqueue(input[rowStartIdx][col]);
        }
        // right
        for (var row = rowStartIdx; row < rowEndIdx; row++)
        {
            queue.Enqueue(input[row][colEndIdx]);
            input[row][colEndIdx] = queue.Dequeue();
        }
        // bottom
        for (var col = colEndIdx; col > colStartIdx; col--)
        {
            queue.Enqueue(input[rowEndIdx][col]);
            input[rowEndIdx][col] = queue.Dequeue();
        }
        // left
        for (var row = rowEndIdx; row > rowStartIdx; row--)
        {
            queue.Enqueue(input[row][colStartIdx]);
            input[row][colStartIdx] = queue.Dequeue();
        }
        // back to top
        for (var col = colStartIdx; col < colEndIdx; col++)
        {
            input[rowStartIdx][col] = queue.Dequeue();
        }

        Rotate(input, rowStartIdx + 1, colStartIdx + 1, size - 2, queue);
    }

    // Learning
    // Rotate 90 -> transpose each row to col, then reverse each row
    // 1 4 7
    // 2 5 8
    // 3 6 9

    // 7 4 1
    // 8 5 2
    // 9 8 3

    // Rotate 180 -> reverse each row, then reverse each column
    // 3 2 1
    // 6 5 4
    // 9 8 7

    // 9 8 7
    // 6 5 4
    // 3 2 1

    // Rotate 270 -> transpose each row to col, then reverse each column
    // 1 4 7
    // 2 5 8
    // 3 6 9

    // 3 6 9
    // 2 5 8
    // 1 4 7    
    public static TheoryData<int[][], int[][]> TestData => new()
    {
        {
            [[1]],[[1]]
        },
        {
            [[1,2],[4,3]],
            [[4,1],[3,2]]
        },
        {
            [[1,2,3],[4,5,6],[7,8,9]],
            [[7,4,1],[8,5,2],[9,6,3]]
        },
        {
            [[5,1,9,11],[2,4,8,10],[13,3,6,7],[15,14,12,16]],
            [[15,13,2,5],[14,3,4,1],[12,6,8,9],[16,7,10,11]]
        }
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[][] input, int[][] expected)
    {
        // Time: O(n^2) for rotate + O(n^2) assert; Space: O(1) extra.
        Rotate(input);
        Assert.Equal(expected, input);
    }
}
