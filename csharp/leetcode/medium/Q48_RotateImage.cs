public class Q48_RotateImage
{
    // TC: O(n^2), n scale with length of matrix
    // SC: O(n), only whole a row or a column
    private void Rotate(int[][] matrix)
    {
        var queue = new Queue<int>();
        Rotate(matrix, 0, 0, matrix.Length, queue);
    }

    private void Rotate(int[][] input, int rowStartIdx, int colStartIdx, int size, Queue<int> queue)
    {
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
        Rotate(input);
        Assert.Equal(expected, input);
    }
}
