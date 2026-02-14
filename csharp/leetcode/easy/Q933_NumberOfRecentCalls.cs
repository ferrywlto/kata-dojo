public interface RecentCounter
{
    public int Ping(int t);
}

// TC: O(n), n is number of calls received
// SC: O(n), n is queue size of calls within 3 seconds
class Q933_NumberOfRecentCalls : RecentCounter
{
    readonly Queue<int> calls = [];
    public int Ping(int t)
    {
        while (calls.Count != 0 && calls.Peek() < t - 3000)
        {
            calls.Dequeue();
        }
        calls.Enqueue(t);
        return calls.Count;
    }
}

class Q933_NumberOfRecentCallsTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int[]{1, 100, 3001, 3002}, new int[]{1, 2, 3, 3}],
    ];
}

public class Q933_NumberOfRecentCallsTests
{
    [Theory]
    [ClassData(typeof(Q933_NumberOfRecentCallsTestData))]
    public void OfficialTestCases(int[] input, int[] expected)
    {
        var sut = new Q933_NumberOfRecentCalls();
        for (var i = 0; i < input.Length; i++)
        {
            Assert.Equal(expected[i], sut.Ping(input[i]));
        }
    }
}
