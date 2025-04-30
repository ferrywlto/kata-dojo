public class Q1828_QueryiesNumPointsInsideCircle
{
    // TC: O(n * m), n scale with number of points, m scale with number of queries
    // SC: O(m), to hold the result
    public int[] CountPoints(int[][] points, int[][] queries)
    {
        var qLen = queries.Length;
        var result = new int[qLen];
        for (var i = 0; i < qLen; i++)
        {
            var count = 0;
            var centerX = queries[i][0];
            var centerY = queries[i][1];
            var radius = queries[i][2];
            for (var j = 0; j < points.Length; j++)
            {
                var pX = points[j][0];
                var pY = points[j][1];
                var xDiff = pX - centerX;
                var aSq = xDiff * xDiff;
                var yDiff = pY - centerY;
                var bSq = yDiff * yDiff;
                var rSq = radius * radius;
                if (aSq + bSq <= rSq) count++;
            }
            result[i] = count;
        }
        return result;
    }
    public static TheoryData<int[][], int[][], int[]> TestData => new()
    {
        {
            [[1,3],[3,3],[5,3],[2,2]],
            [[2,3,1],[4,3,1],[1,1,2]],
            [3,2,2]
        },
        {
            [[1,1],[2,2],[3,3],[4,4],[5,5]],
            [[1,2,2],[2,2,2],[4,3,2],[4,3,3]],
            [2,3,2,4]
        },
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[][] p, int[][] q, int[] expected)
    {
        var actual = CountPoints(p, q);
        Assert.Equal(expected, actual);
    }
}