public class NeighborSum
{

    public NeighborSum(int[][] grid)
    {

    }

    public int AdjacentSum(int value)
    {
        return 0;
    }

    public int DiagonalSum(int value)
    {
        return 0;
    }
}

public class Q3242_DesignNeighborSumService
{
    public static TheoryData<string[], int[][], int[], int[]> TestData => new()
    {
        {
            ["adjacentSum", "adjacentSum", "diagonalSum", "diagonalSum"],
            [[0, 1, 2], [3, 4, 5], [6, 7, 8]],
            [1, 4, 4, 8],
            [6, 16, 16, 4]
        },
        {
            ["adjacentSum", "diagonalSum"],
            [[1, 2, 0, 3], [4, 7, 15, 6], [8, 9, 10, 11], [12, 13, 14, 5]],
            [15, 9],
            [23, 45]
        }
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string[] commands, int[][] init, int[] input, int[] expected)
    {
        var sut = new NeighborSum(init);
        for(var i=0; i<commands.Length; i++)
        {
            var cmd = commands[i];
            switch(cmd)
            {
                case "adjacentSum":
                    Assert.Equal(expected[i], sut.AdjacentSum(input[i]));
                    break;
                case "diagonalSum":
                    Assert.Equal(expected[i], sut.DiagonalSum(input[i]));
                    break;
            }
        }
    }
}