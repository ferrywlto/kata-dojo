public interface RecentCounter 
{
    public int Ping(int t);
}

class Q933_NumberOfRecentCalls : RecentCounter
{
    Dictionary<int, int> calls = new();
    public int Ping(int t)
    {
        return 0;
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
        for(var i=0; i< input.Length; i++)
        {
            Assert.Equal(expected[i], sut.Ping(input[i]));
        }
    }
}