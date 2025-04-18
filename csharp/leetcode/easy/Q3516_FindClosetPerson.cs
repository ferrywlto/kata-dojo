public class Q3516_FindClosetPerson
{
    public int FindClosest(int x, int y, int z)
    {
        return 0;
    }
    public static TheoryData<int, int, int, int> TestData => new()
    {
        {2,7,4,1},
        {2,5,6,2},
        {1,5,3,0},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int x, int y, int z, int expected)
    {
        var actual = FindClosest(x, y, z);
        Assert.Equal(expected, actual);
    }
}
