public class Q2326_SpiralMatrixIV
{
    // TC: O(n), n scale with length of head
    // SC: O(n * m), for storing the result, otherwise O(1)
    public int[][] SpiralMatrix(int m, int n, ListNode head)
    {
        var result = new int[m][];
        for (var i = 0; i < m; i++)
        {
            result[i] = new int[n];
            for (var j = 0; j < n; j++)
            {
                result[i][j] = -1;
            }
        }

        var top = 0;
        var bottom = m - 1;
        var left = 0;
        var right = n - 1;
        var direction = 0;
        var node = head;
        while (node != null)
        {
            if (direction % 4 == 0)
            {
                for (var col = left; col <= right; col++)
                {
                    if (node == null) break;
                    result[top][col] = node.Val;
                    node = node.Next;
                }
                direction++;
                top++;
            }
            else if (direction % 4 == 1)
            {
                for (var row = top; row <= bottom; row++)
                {
                    if (node == null) break;
                    result[row][right] = node.Val;
                    node = node.Next;
                }
                direction++;
                right--;
            }
            else if (direction % 4 == 2)
            {
                for (var col = right; col >= left; col--)
                {
                    if (node == null) break;
                    result[bottom][col] = node.Val;
                    node = node.Next;
                }
                direction++;
                bottom--;
            }
            else
            {
                for (var row = bottom; row >= top; row--)
                {
                    if (node == null) break;
                    result[row][left] = node.Val;
                    node = node.Next;
                }
                direction++;
                left++;
            }
        }
        return result;
    }
    public static TheoryData<int, int, ListNode, int[][]> TestData => new()
    {
        {
            3, 5,
            ListNode.FromArray([3,0,2,6,8,1,7,9,4,2,5,5,0])!,
            [
                [3,0,2,6,8],
                [5,0,-1,-1,1],
                [5,2,4,9,7]
            ]
        },
        {
            1, 4,
            ListNode.FromArray([0,1,2])!,
            [[0,1,2,-1]]
        }
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int m, int n, ListNode input, int[][] expected)
    {
        var actual = SpiralMatrix(m, n, input);
        Assert.Equal(expected, actual);
    }
}