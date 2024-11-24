public class Q2500_DeleteGreatestValueInEachRow(ITestOutputHelper output)
{
    public int DeleteGreatestValue(int[][] grid)
    {
        var result = new int[grid[0].Length];
        for (var k = 0; k < grid[0].Length; k++)
        {
            var max = int.MinValue;
            for (var i = 0; i < grid.Length; i++)
            {
                var row = grid[i];
                var rowMax = int.MinValue;
                var rowMaxIdx = -1;
                for (var j = 0; j < row.Length; j++)
                {
                    if (row[j] > rowMax)
                    {
                        rowMax = row[j];
                        rowMaxIdx = j;
                    }
                }
                row[rowMaxIdx] = int.MinValue;

                if (rowMax > max)
                {
                    max = rowMax;
                }
            }
            result[k] = max;
            output.WriteLine("k: {0}, max: {1}, result:{2}, ", k, max, result[k]);
        }
        return result.Sum();
    }
    public static List<object[]> TestData =>
    [
        [
            new int[][]
            {
                [1,2,4],[3,3,1]
            }, 8
        ],
        [
            new int[][]
            {
                [10]
            }, 10
        ]
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[][] input, int expected)
    {
        var actual = DeleteGreatestValue(input);
        Assert.Equal(expected, actual);
    }
}