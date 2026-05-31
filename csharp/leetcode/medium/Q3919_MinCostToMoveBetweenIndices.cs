public class Q3919_MinCostToMoveBetweenIndices
{
    public int[] MinCost(int[] nums, int[][] queries)
    {
        var nLen = nums.Length;
        var closestIdx = new int[nLen];

        // Calculate the closest
        for (var i = 0; i < nLen; i++)
        {
            if (i == 0)
            {
                closestIdx[i] = 1;
                continue;
            }
            if (i == nLen - 1)
            {
                closestIdx[i] = nLen - 2;
                continue;
            }

            var fromLeft = Math.Abs(nums[i] - nums[i - 1]);
            var fromRight = Math.Abs(nums[i] - nums[i + 1]);
            if (fromRight < fromLeft) closestIdx[i] = i + 1;
            else closestIdx[i] = i - 1;
        }

        var qLen = queries.Length;
        var result = new int[qLen];
        for (var i = 0; i < qLen; i++)
        {
            var currentQuery = queries[i];
            // Array.Sort(currentQuery);
            var start = currentQuery[0];
            var end = currentQuery[1];

            var directCost = Math.Abs(nums[start] - nums[end]);
            var minCost = directCost;
            var currentCost = 0;
            if (start < end)
            {
                for (var idx = start; idx < end; idx++)
                {
                    var nextidx = closestIdx[idx];
                    currentCost += 1;
                    var intermCost = currentCost + Math.Abs(nums[nextidx] - nums[end]);
                    if (intermCost < minCost)
                    {
                        minCost = intermCost;
                        idx = nextidx;
                    }
                }
            }
            else
            {
                for (var idx = end; idx > start; idx--)
                {
                    var nextidx = closestIdx[idx];
                    currentCost += 1;
                    var intermCost = currentCost + Math.Abs(nums[nextidx] - nums[end]);
                    if (intermCost < minCost)
                    {
                        minCost = intermCost;
                        idx = nextidx;
                    }
                }
            }

            result[i] = minCost;
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
