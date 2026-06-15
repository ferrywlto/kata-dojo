public class Q3923_MinGenerationsToTargetPoint
{
    public readonly record struct Point(int X, int Y, int Z);
    private Point ToPoint(int[] input) => new(input[0], input[1], input[2]);

    // TC: O(n^2)
    // SC: O(n), n scales with length of points
    public int MinGenerations(int[][] points, int[] target)
    {
        Point targetPoint = ToPoint(target);
        var seen = new HashSet<Point>();
        var all = new List<Point>();
        var frontier = new List<Point>();

        for (var i = 0; i < points.Length; i++)
        {
            var p = ToPoint(points[i]);
            if (p == targetPoint) return 0;
            seen.Add(p);
            all.Add(p);
        }

        if (seen.Count < 2) return -1;

        var result = 1;

        // Generate Frontier
        for (var i = 0; i < all.Count - 1; i++)
        {
            for (var j = i + 1; j < all.Count; j++)
            {
                var p = GenPoint(all[i], all[j]);
                if (p == targetPoint) return result;

                if (!seen.Add(p)) continue;
                frontier.Add(p);
            }
        }

        if (frontier.Count == 0) return -1;

        result++;

        while (true)
        {
            var next = new List<Point>();
            // all x frontier
            for (var i=0; i<all.Count; i++)
            {
                for(var j=0; j<frontier.Count; j++)
                {
                    var p = GenPoint(all[i], frontier[j]);
                    if (p == targetPoint) return result;

                    if (!seen.Add(p)) continue;

                    next.Add(p);
                }
            }

            // frontier x frontier
            for (var i = 0; i < frontier.Count - 1; i++)
            {
                for (var j= i + 1 ; j< frontier.Count; j++)
                {
                    var p = GenPoint(frontier[i], frontier[j]);
                    if (p == targetPoint) return result;

                    if (!seen.Add(p)) continue;

                    next.Add(p);
                }
            }

            if (next.Count == 0) return -1;

            all.AddRange(frontier);
            frontier.Clear();

            frontier.AddRange(next);
            next.Clear();
            result++;
        }
    }
    private Point GenPoint(Point a, Point b)
    {
        return new Point(
            (a.X + b.X) / 2,
            (a.Y + b.Y) / 2,
            (a.Z + b.Z) / 2);
    }

    public static TheoryData<int[][], int[], int> TestData => new()
    {
        { [[0, 0, 0], [6, 6, 6]], [3, 3, 3], 1 },
        { [[0, 0, 0], [5, 5, 5]], [1, 1, 1], 2 },
        { [[0, 0, 0], [2, 2, 2], [3, 3, 3]], [2, 2, 2], 0 },
        { [[1, 2, 3]], [5, 5, 5], -1 },
        { [[0, 6, 1]], [0, 6, 1], 0 },
        { [[2, 0, 5], [0, 5, 5]], [0, 2, 4], -1 },
        { [[4, 3, 4], [1, 0, 5]], [1, 1, 6], -1 },
        { [[1, 6, 1], [6, 3, 6]], [5, 2, 2], -1 },
        { [[0, 3, 3], [4, 0, 1]], [3, 0, 1], 2 },
        { [[6, 6, 1], [4, 2, 5]], [4, 4, 2], 4 },
        { [[1, 4, 2], [2, 1, 2], [4, 0, 3]], [1, 0, 2], 3 }
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[][] points, int[] target, int expected)
    {
        var actual = MinGenerations(points, target);
        Assert.Equal(expected, actual);
    }
}
