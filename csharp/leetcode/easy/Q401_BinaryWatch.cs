namespace dojo.leetcode;

public class Q401_BinaryWatch
{
    public IList<string> ReadBinaryWatch(int turnedOn)
    {
        return [];
    }
}

public class Q401_BinaryWatchTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [1, new List<string> {"0:01", "0:02", "0:04", "0:08", "0:16", "0:32", "1:00"}],
        [9, new List<string> {}],
    ];
}

public class Q401_BinaryWatchTests
{
    [Theory]
    [ClassData(typeof(Q401_BinaryWatchTestData))]
    public void OfficialTestCases(int turnedOn, IList<string> expected)
    {
        var q = new Q401_BinaryWatch();
        IList<string> result = q.ReadBinaryWatch(turnedOn);
        Assert.True(Enumerable.SequenceEqual(expected, result));
    }
}
