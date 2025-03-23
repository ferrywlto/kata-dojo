public class Q3492_MaximumContainersOnShip
{
    // TC: O(1)
    // SC: O(1)
    public int MaxContainers(int n, int w, int maxWeight)
    {
        var numOfContainers = n * n;

        return Math.Min(numOfContainers, maxWeight / w);
    }
    public static TheoryData<int, int, int, int> TestData => new()
    {
        {2, 3, 15, 4},
        {3, 5, 20, 4},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int input1, int input2, int input3, int expected)
    {
        var actual = MaxContainers(input1, input2, input3);
        Assert.Equal(expected, actual);
    }
}