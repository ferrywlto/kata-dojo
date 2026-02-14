public class Q3238_FindNumberOfWinningPlayer
{
    // TC: O(n), n scale with length of pick
    // SC: O(m), m scale with unique number of player in pick
    public int WinningPlayerCount(int n, int[][] pick)
    {
        var dict = new Dictionary<int, int[]>();
        var winners = new HashSet<int>();

        for (var i = 0; i < pick.Length; i++)
        {
            var player = pick[i][0];
            var color = pick[i][1];

            if (winners.Contains(player)) continue;

            if (dict.TryGetValue(player, out var colors))
            {
                colors[color]++;
            }
            else
            {
                colors = new int[11];
                colors[color]++;
                dict.Add(player, colors);
            }
            if (colors[color] > player) winners.Add(player);
        }

        return winners.Count;
    }
    // TC: O(n * m), m scale with length of pick
    // SC: O(1), space used does not scale with input
    public int WinningPlayerCount2(int n, int[][] pick)
    {
        var result = 0;
        for (var i = 0; i <= n; i++)
        {
            var colors = new int[11];
            for (var j = 0; j < pick.Length; j++)
            {
                var player = pick[j][0];
                if (player != i) continue;

                var color = pick[j][1];
                colors[color]++;

                if (colors[color] > i)
                {
                    result++;
                    break;
                }
            }
        }

        return result;
    }

    // TC: O(n + m), m scale with length of pick
    // SC: O(1), space used does not scale with input
    public int WinningPlayerCount_Optimal(int n, int[][] pick)
    {
        const int color_len = 11;
        var result = 0;
        var flatten = new int[n + 1][];
        for (var i = 0; i <= n; i++)
        {
            flatten[i] = new int[color_len];
        }

        for (var j = 0; j < pick.Length; j++)
        {
            var player = pick[j][0];
            var color = pick[j][1];
            flatten[player][color]++;
        }

        for (var i = 0; i <= n; i++)
        {
            for (var j = 0; j < color_len; j++)
            {
                if (flatten[i][j] > i)
                {
                    result++;
                    break;
                }
            }
        }

        return result;
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
        var actual = WinningPlayerCount_Optimal(input1, input2);
        Assert.Equal(expected, actual);
    }
}
