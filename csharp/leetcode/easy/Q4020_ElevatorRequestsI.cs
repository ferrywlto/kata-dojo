public class Q4020_ElevatorRequestsI
{
    public int ElevatorRequests(int n, int[] requests)
    {
        return 0;
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
