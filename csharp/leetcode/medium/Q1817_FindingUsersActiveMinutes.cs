public class Q1817_FindingUsersActiveMinutes
{
    // TC: O(n + p + m), n scale with length of logs, p scale with number of user, m scale with unique UAM
    // SC: O(p + m) 
    public int[] FindingUsersActiveMinutes(int[][] logs, int k)
    {
        var len = logs.Length;
        var dict = new Dictionary<int, HashSet<int>>();
        for (var i = 0; i < len; i++)
        {
            (var id, var time) = (logs[i][0], logs[i][1]);
            if (dict.TryGetValue(id, out var set))
            {
                set.Add(time);
            }
            else dict.Add(id, [time]);
        }
        var uams = new Dictionary<int, int>();
        foreach (var p in dict)
        {
            var uamCount = p.Value.Count;
            if (uams.TryGetValue(uamCount, out var val))
            {
                uams[uamCount] = ++val;
            }
            else uams.Add(uamCount, 1);
        }

        var result = new int[k];
        foreach (var p in uams)
        {
            result[p.Key - 1] = p.Value;
        }
        return result;
    }
    public static TheoryData<int[][], int, int[]> TestData => new()
    {
        {[[0,5],[1,2],[0,2],[0,5],[1,3]], 5, [0,2,0,0,0]},
        {[[1,1],[2,2],[2,3]], 4, [1,1,0,0]},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[][] input, int k, int[] expected)
    {
        var actual = FindingUsersActiveMinutes(input, k);
        Assert.Equal(expected, actual);
    }
}
