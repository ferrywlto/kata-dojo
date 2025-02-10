public class Q3178_FindTheChildWhoHasTheBallAfterKSeconds
{
    // TC: O(k)
    // SC: O(1)
    public int NumberOfChild(int n, int k)
    {
        var currentIdx = 0;
        var direction = 1;
        while (k > 0)
        {
            currentIdx += direction;
            if (currentIdx == 0 || currentIdx == n - 1) direction *= -1;
            k--;
        }
        return currentIdx;
    }
    public static TheoryData<int, int, int> TestData => new()
    {
        {3, 5, 1},
        {5, 6, 2},
        {4, 2, 2},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int input, int k, int expected)
    {
        var actual = NumberOfChild(input, k);
        Assert.Equal(expected, actual);
    }
}