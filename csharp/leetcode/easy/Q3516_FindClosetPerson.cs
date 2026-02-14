public class Q3516_FindClosetPerson
{
    // TC: O(1), the time required is constant
    // SC: O(1), same as time
    public int FindClosest(int x, int y, int z)
    {
        var diffX = Math.Abs(z - x);
        var diffY = Math.Abs(z - y);
        if (diffX == diffY) return 0;

        return diffX < diffY ? 1 : 2;
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
