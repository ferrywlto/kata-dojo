public class Q1823_FindWinnerOfCircularGame(ITestOutputHelper output) : ListNodeTest(output)
{
    // TC: O(n)
    // SC: O(n)
    public int FindTheWinner(int n, int k)
    {
        var seats = new int[501];
        // for (var i = 0; i < n; i++) seats[i] = i;

        var seatsLeft = n;
        var currIdx = 0;
        while (seatsLeft > 1)
        {
            currIdx = (currIdx + k - 1) % n;
            Output.WriteLine("A {0}, {1}", currIdx, seats[currIdx]);
            while (seats[currIdx] != 0)
            {
                Output.WriteLine("- {0}", currIdx);
                currIdx++;
            }
            seats[currIdx] = 1;
            seatsLeft--;
            currIdx++;
        }
        for (var i = 0; i < seats.Length; i++)
        {
            if (seats[i] == 0) return i;
        }
        return -1;
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