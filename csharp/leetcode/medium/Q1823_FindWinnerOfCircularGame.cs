public class Q1823_FindWinnerOfCircularGame(ITestOutputHelper output) : ListNodeTest(output)
{
    // TC: O(n)
    // SC: O(n)
    public int FindTheWinner(int n, int k)
    {
        var list = new List<int>();
        for (var i = 1; i <= n; i++) list.Add(i);

        var currentIdx = 0;
        while (list.Count > 1)
        {
            currentIdx = (currentIdx + k - 1) % list.Count;
            list.RemoveAt(currentIdx);
            currentIdx %= list.Count;
        }
        return list[0];
    }
    public static TheoryData<int, int, int> TestData => new()
    {
        {5, 2, 3},
        {6, 5, 1},
        {3, 1, 3},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int n, int k, int expected)
    {
        var actual = FindTheWinner(n, k);
        Assert.Equal(expected, actual);
    }
}