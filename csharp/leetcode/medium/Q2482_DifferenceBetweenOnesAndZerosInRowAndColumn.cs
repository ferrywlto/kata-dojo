public class Q2482_DifferenceBetweenOnesAndZerosInRowAndColumn
{
    public int[][] OnesMinusZeros(int[][] grid)
    {
        var m = grid.Length;
        var n = grid[0].Length;
        var rowOnes = new int[m];
        var colOnes = new int[n];
        var rowZeros = new int[m];
        var colZeros = new int[n];

        for(var row=0; row<m; row++)
        {
            for(var col=0; col<grid[row].Length; col++) 
            {
                if(grid[row][col] == 1) {
                    rowOnes[row]++;
                    colOnes[col]++;
                }
                else {
                    rowZeros[row]++;
                    colZeros[col]++;
                };
            }
        }
        var result = new int[m][];
        for(var i=0; i<m; i++) {result[i] = new int[n];}
                
        for(var row=0; row<m; row++)
        {
            for(var col=0; col<grid[row].Length; col++) 
            {
                result[row][col] = rowOnes[row] + colOnes[col] - rowZeros[row] - colZeros[col];
            }
        }        
        return result;
    }
    public static TheoryData<int[][], int[][]> TestData => new()
    {
        {
            [
                [0,1,1],
                [1,0,1],
                [0,0,1]
            ],
            [
                [0,0,4],
                [0,0,4],
                [-2,-2,2]
            ]
        },
        {
            [
                [1,1,1],
                [1,1,1]
            ],
            [
                [5,5,5],
                [5,5,5]
            ]
        },
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[][] input, int[][] expected)
    {
        var actual = OnesMinusZeros(input);
        Assert.Equal(expected, actual);
    }
}