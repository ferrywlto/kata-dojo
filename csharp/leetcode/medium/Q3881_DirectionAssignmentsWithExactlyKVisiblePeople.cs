public class Q3881_DirectionAssignmentsWithExactlyKVisiblePeople
{
    public int CountVisiblePeople(int n, int pos, int k)
    {
        return 0;
    }

    public static TheoryData<int, int, int, int> TestData => new() { { 3, 1, 0, 2 }, { 3, 2, 1, 4 }, { 1, 0, 0, 2 } };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int n, int pos, int k, int expected)
    {
        var actual = CountVisiblePeople(n, pos, k);
        Assert.Equal(expected, actual);
    }
}
