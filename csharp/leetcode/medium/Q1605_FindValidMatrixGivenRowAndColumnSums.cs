public class Q1605_FindValidMatrixGivenRowAndColumnSums
{
    public int[][] RestoreMatrix(int[] rowSum, int[] colSum)
    {
        var result = new int[rowSum.Length][];
        for(var i=0; i<result.Length; i++)
        {
            result[i] = new int[colSum.Length];
        }


        var (idx, val, who) = FindSmallest(rowSum, colSum);
        if(who == "row")
        {
            rowSum[idx]-=val;
            colSum[idx]-=val;
            result[idx][idx] = val;
        }
        
        return [[]];
    }

    private (int idx, int val, string who) FindSmallest(int[] rowSum, int[] colSum)
    {
        var (srIdx, sr) = FindSmallest(rowSum);
        var (scIdx, sc) = FindSmallest(colSum);

        if(sr > sc) return (srIdx, sr, "row");
        else return(scIdx, sc, "col");
    }

    private (int idx, int val) FindSmallest(int[] input)
    {
        var smallest = int.MaxValue;
        var smallestIdx = int.MaxValue;
        for(var i=0; i<input.Length; i++)
        {
            if(input[i] < smallest)
            {
                smallest = input[i];
                smallestIdx = i;
            }
        }
        return (smallestIdx, smallest);
    }

    public static TheoryData<int[], int[]> TestData => new ()
    {
        {[3,8], [4,7]},
        {[5,7,10], [8,6,8]},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] rowSum, int[] colSum)
    {
        var actual = RestoreMatrix(rowSum, colSum);
        var rows = new int[actual.Length];
        var cols = new int[actual[0].Length];

        for(var r=0; r<rows.Length; r++)
        {
            rows[r] = actual[r].Sum();
            
        }
        var cSum = 0;
        for(var c=0; c<cols.Length; c++)
        {
            for(var r=0; r<rows.Length; r++)
            {
                cSum+= actual[r][c];
            }
        }

        Assert.Equal(rowSum, rows);
        Assert.Equal(colSum, cols);
    }
}
