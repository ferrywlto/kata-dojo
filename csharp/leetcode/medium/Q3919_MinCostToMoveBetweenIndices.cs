public class Q3919_MinCostToMoveBetweenIndices(ITestOutputHelper output)
{
    public int[] MinCost(int[] nums, int[][] queries)
    {
        var len = nums.Length;
        var costs = new int[len][];
        for (var i = 0; i < costs.Length; i++) costs[i] = new int[len];

        var closestIdx = new int[len];

        for (var i = 0; i < len; i++)
        {
            var minCost = int.MaxValue;
            for (var j = 0; j < len; j++)
            {
                var cost = Math.Abs(nums[i] - nums[j]);
                costs[i][j] = cost;
                if (i != j && cost < minCost)
                {
                    minCost = cost;
                    closestIdx[i] = j;
                }
            }
        }
        output.WriteLine($"closest: [{string.Join(',', closestIdx)}]");
        for (var i = 0; i < costs.Length; i++)
        {
            output.WriteLine($"cost: [{string.Join(',', costs[i])}]");
        }

        var result = new int[queries.Length];
        // prevent circular path
        var seen = new HashSet<int>();
        for (var i = 0; i < queries.Length; i++)
        {
            var q = queries[i];
            var start = q[0];
            var end = q[1];
            var closestCost = 0;

            seen.Clear();
            seen.Add(start);
            while (start != end)
            {
                if (Math.Abs(start - end) == 1)
                {
                    closestCost += costs[start][end];
                    break;
                }

                var next = closestIdx[start];
                if (seen.Add(next))
                {
                    output.WriteLine($"next: {next}");
                    closestCost++;
                    start = next;
                }
                else
                {
                    output.WriteLine($"final: cost[{start}][{end}]: {costs[start][end]}");
                    closestCost += costs[start][end];
                    break;
                }
            }

            result[i] = closestCost;
        }

        return result;

    }

    public static TheoryData<int[], int[][], int[]> TestData => new()
    {
        {
            [-5, -2, 3], [[0, 2], [2, 0], [1, 2]], [6, 2, 5]
        },
        {
            [0, 2, 3, 9], [[3, 0], [1, 2], [2, 0]], [4, 1, 3]
        }
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int[][] queries, int[] expected)
    {
        var actual = MinCost(input, queries);
        Assert.Equal(expected, actual);
    }
}
