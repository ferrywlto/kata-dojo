public class Q3783_MirrorDistanceOfInteger
{
    public int MirrorDistance(int n)
    {
        return 0;
    }
    public static TheoryData<int, int> TestData => new()
    {
        {25 ,27},
        {10 ,9},
        {7 ,0},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int input, int expected)
    {
        var actual = MirrorDistance(input);
        Assert.Equal(expected, actual);
    }
}
