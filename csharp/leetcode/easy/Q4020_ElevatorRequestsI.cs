public class Q4020_ElevatorRequestsI
{
    // TC: O(n)
    // SC: O(1)
    public int ElevatorRequests(int n, int[] requests)
    {
        var prevFloor = 0;
        var result = 0;
        for (var i = 0; i < requests.Length; i++)
        {
            result += Math.Abs(prevFloor - requests[i]);
            prevFloor = requests[i];
        }
        return result;
    }

    public static TheoryData<int, int[], int> TestData => new()
    {
        { 5, [2, 1, 4, 3], 7 },
        { 3, [2, 0, 0], 4 },
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int n, int[] requests, int expected)
    {
        var actual = ElevatorRequests(n, requests);
        Assert.Equal(expected, actual);
    }
}
