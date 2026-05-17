public class Q3932_CountKthRootsInRange
{
    public int CountKthRoots(int l, int r, int k)
    {
        return 0;
    }

    public static TheoryData<int, int, int, int> TestData => new() { { 1, 9, 3, 2 }, { 8, 30, 2, 3 } };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int l, int r, int k, int expected)
    {
        var actual = CountKthRoots(l, r, k);
        Assert.Equal(expected, actual);
    }
}
