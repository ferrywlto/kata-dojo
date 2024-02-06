namespace dojo.leetcode;

public class Q401_BinaryWatch
{
    int[]? Bits;
    Dictionary<int, List<string>> PossibleTime = [];

    // 1111 111111 4bits for hour and 6bits for minute
    // minute mask 0011 1111 -> 0b111111

    // TC: O(n) for first pass, O(1) afterwards, SC: O(n)
    public IList<string> ReadBinaryWatch(int turnedOn)
    {
        // for hour, at most 3 bits on as 4 bits on will > 12
        // for minutes, at most 5 bits on as 6 bits on will > 59
        // so if turnedOn > 8 has no possible time represented  
        if (turnedOn > 8) return [];

        if (PossibleTime.TryGetValue(turnedOn, out var timeList))
        {
            return timeList;
        }

        // 1024 because of 10 bits
        Bits ??= new Q338_CountingBits().CountBits_Faster(1024);
        var result = new List<string>();

        var filtered = Bits
            .Select((i, idx) => (idx, i))
            .Where(x => x.i == turnedOn)
            .Select(x => (x.idx >> 6, x.idx & 0b111111))
            .Where(x => x.Item1 < 12 && x.Item2 < 60)
            .Select(x => $"{x.Item1}:{x.Item2.ToString().PadLeft(2,'0')}")
            .ToList();

        PossibleTime.Add(turnedOn, filtered);
        return filtered;
    }
}

public class Q401_BinaryWatchTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [1, new List<string> {"0:01", "0:02", "0:04", "0:08", "0:16", "0:32", "1:00","2:00","4:00","8:00"}],
        [2, new List<string> {
            "0:03","0:05","0:06","0:09","0:10","0:12","0:17","0:18","0:20","0:24","0:33","0:34","0:36","0:40","0:48",
            "1:01","1:02","1:04","1:08","1:16","1:32","2:01","2:02","2:04","2:08","2:16","2:32","3:00","4:01","4:02",
            "4:04","4:08","4:16","4:32","5:00","6:00","8:01","8:02","8:04","8:08","8:16","8:32","9:00","10:00"}],
        [9, new List<string> {}],
    ];
}

public class Q401_BinaryWatchTests(ITestOutputHelper helper)
{
    [Theory]
    [ClassData(typeof(Q401_BinaryWatchTestData))]
    public void OfficialTestCases(int turnedOn, IList<string> expected)
    {
        var q = new Q401_BinaryWatch();
        IList<string> result = q.ReadBinaryWatch(turnedOn);
        helper.WriteLine(string.Join(",", result));
        Assert.True(Enumerable.SequenceEqual(expected, result));
    }
}
