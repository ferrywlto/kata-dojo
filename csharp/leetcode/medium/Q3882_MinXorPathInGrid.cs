public class Q3882_MinXorPathInGrid(ITestOutputHelper output)
{
    // TC: O(m * n * 1024)
    // SC: O(n * 1024)
    public int MinCost(int[][] grid)
    {
        // Since constraints says grid[i][j] < 1024
        // Walkthrough each cell from top left to bottom right row per row
        // On each cell we only consider which direction XOR can comes from.
        // Then at the end the minimal true index is the minimal possible XOR path result to the end.
        var numRows = grid.Length;
        var numCols = grid[0].Length;

        var possibleXors = new bool[numRows * numCols][];
        for (var i = 0; i < possibleXors.Length; i++)
            possibleXors[i] = new bool[1024];

        possibleXors[0][grid[0][0]] = true;

        // init the first row, cells from first row only possible XOR from left
        for (var col = 1; col < numCols; col++)
        {
            var currentPossible = possibleXors[col];
            var possibleFromLeft = possibleXors[col-1];
            for (var s = 0; s < possibleFromLeft.Length; s++)
            {
                if(possibleFromLeft[s])
                    currentPossible[s ^ grid[0][col]] = true;
            }
        }

        // for other rows XOR can comes from left and top.
        for (var row = 1; row < numRows; row++)
        {
            output.WriteLine("row 1");
            for (var col = 0; col < numCols; col++)
            {
                var currentPossible = possibleXors[row * numCols + col];
                var possibleFromTop = possibleXors[(row - 1) * numCols + col];
                for (var t = 0; t < possibleFromTop.Length; t++)
                {
                    if (possibleFromTop[t])
                        currentPossible[t ^ grid[row][col]] = true;
                }

                if (col > 0)
                {
                    var possibleFromLeft = possibleXors[row * numCols + col - 1];
                    for (var l = 0; l < possibleFromLeft.Length; l++)
                    {
                        if (possibleFromLeft[l])
                            currentPossible[l ^ grid[row][col]] = true;
                    }
                }
            }
        }

        // The first true idx of last cell XOR result is minimal
        var lastSeen = possibleXors[^1];
        for (var i = 0; i < lastSeen.Length; i++)
            if (lastSeen[i]) return i;

        return -1;
    }


    public static TheoryData<int[][], int> TestData => new()
    {
        {[[1,2],[3,4]], 6},
        {[[6,7],[5,8]], 9},
        {[[2,7,5]], 0},
        { [[19],[5]], 22},
        {[[9,6,19,8],[32,28,20,23],[2,5,22,22]], 6},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[][] input, int expected)
    {
        var actual = MinCost(input);
        Assert.Equal(expected, actual);
    }
}
