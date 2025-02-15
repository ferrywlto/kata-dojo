public class Q3238_FindNumberOfWinningPlayer
{
    public int WinningPlayerCount(int n, int[][] pick)
    {
        var dict = new Dictionary<int, int[]>();
        var winners = new HashSet<int>();

        for(var i=0; i<pick.Length; i++)
        {
            var player = pick[i][0];
            var color = pick[i][1];
            
            if(winners.Contains(player)) continue;

            if(dict.TryGetValue(player, out var colors))
            {
                colors[color]++;
            }
            else 
            {
                colors = new int[11];
                colors[color]++;
                dict.Add(player, colors);
            }
            if(colors[color] > player) winners.Add(player);
        }

        return winners.Count;
    }
    public static TheoryData<int, int[][], int> TestData => new()
    {
        {4, [[0,0],[1,0],[1,0],[2,1],[2,1],[2,0]], 2},
        {5, [[1,1],[1,2],[1,3],[1,4]], 0},
        {5, [[1,1],[2,4],[2,4],[2,4]], 1},
        {2, [[0,8],[0,3]], 1},
        {3, [[1,3],[2,10]], 0},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int input1, int[][] input2, int expected)
    {
        var actual = WinningPlayerCount(input1, input2);
        Assert.Equal(expected, actual);
    }
}
