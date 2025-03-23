public class Q3492_MaximumContainersOnShip
{
    public int MaxContainers(int n, int w, int maxWeight)
    {
        return 0;
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