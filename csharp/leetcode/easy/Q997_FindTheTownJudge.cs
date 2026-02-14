class Q997_FindTheTownJudge
{
    // TC: O(n), n is length of trust
    // SC: O(n+m), n is distinct vote from trust, m is distinct people in town
    public int FindJudge(int n, int[][] trust)
    {
        if (trust.Length == n) return -1;
        if (trust.Length == 0)
        {
            if (n == 1) return 1;
            else return -1;
        }

        var missing = (1 + n) * n / 2;
        var dict = new Dictionary<int, int>();
        var hashset = new HashSet<int>();
        for (var i = 0; i < trust.Length; i++)
        {
            if (dict.TryGetValue(trust[i][1], out var value))
            {
                dict[trust[i][1]] = ++value;
            }
            else
            {
                dict.Add(trust[i][1], 1);
            }

            if (!hashset.Contains(trust[i][0]))
            {
                missing -= trust[i][0];
                hashset.Add(trust[i][0]);
            }
        }
        if (!dict.ContainsKey(missing)) return -1;
        if (dict[missing] == n - 1) return missing;
        return -1;
    }
}

class Q997_FindTheTownJudgeTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [1, new int[][]{[1,2]}, -1],
        [1, Array.Empty<int[]>(), 1],
        [3, new int[][]{[1,3],[2,3],[3,1]}, -1],
        [3, new int[][]{[1,2],[2,3]}, -1],
        [2, new int[][]{[1,2]}, 2],
        [3, new int[][]{[1,3],[2,3]}, 3],
        [3, new int[][]{[2,3],[1,3]}, 3],
        [4, new int[][]{[1,3],[1,4],[2,3],[2,4],[4,3]}, 3],
    ];
}

public class Q997_FindTheTownJudgeTests
{
    [Theory]
    [ClassData(typeof(Q997_FindTheTownJudgeTestData))]
    public void OfficialTestCases(int input, int[][] trust, int expected)
    {
        var sut = new Q997_FindTheTownJudge();
        var actual = sut.FindJudge(input, trust);
        Assert.Equal(expected, actual);
    }
}
