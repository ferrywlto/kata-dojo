public class Q2946_MatrixSimilarityAfterCyclicShifts
{
    // TC: O(n*n*k), n scale with length of mat, for each row, do the shift k times, each shift do n operations
    // SC: O(m), m scale with length of a row
    public bool AreSimilar(int[][] mat, int k)
    {
        for(var i=0; i<mat.Length; i++)
        {
            var row = mat[i];
            if(row.Length == 1) continue;

            var clone = new int[row.Length];
            Array.Copy(row, clone, clone.Length);

            if(i % 2 == 0) {
                LeftShift(clone, k);
            }
            else {
                RightShift(clone, k);
            }

            if(!clone.SequenceEqual(row)) return false;
        }
        return true;
    }
    private void LeftShift(int[] input, int k)
    {
        for(var i=0; i<k; i++) 
        {
            LeftShift(input);
        }
    }
    private void LeftShift(int[] input)
    {
        var head = input[0];
        for(var i=1; i<input.Length; i++)
        {
            input[i-1] = input[i];
        }
        input[^1] = head;
    }
    private void RightShift(int[] input, int k)
    {
        for(var i=0; i<k; i++) 
        {
            RightShift(input);
        }
    }
    private void RightShift(int[] input)
    {
        var tail = input[^1];
        for(var i=input.Length-1; i>0; i--)
        {
            input[i] = input[i-1];
        }
        input[0] = tail;
    }
    public static TheoryData<int[][], int, bool> TestData => new()
    {
        {
            [
                [1,2,3],
                [4,5,6],
                [7,8,9],
            ], 4, false
        },
        {
            [
                [1,2,1,2],
                [5,5,5,5],
                [6,3,6,3],
            ], 2, true
        },
        {
            [
                [2,2],
                [2,2],
            ], 3, true
        },
        {
            [
                [3,10,3,10,3,10,3,10],
                [5,8,5,8,5,8,5,8],
                [3,9,3,9,3,9,3,9],
                [3,8,3,8,3,8,3,8],
                [2,3,2,3,2,3,2,3]
            ], 2, true
        }
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[][] input, int k, bool expected)
    {
        var actual = AreSimilar(input, k);
        Assert.Equal(expected, actual);
    }
}
