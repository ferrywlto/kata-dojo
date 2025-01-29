public class Q3028_AntOnBoundary
{
    // TC: O(n), n scale with length of nums
    // SC: O(1), space used does not scale with input
    public int ReturnToBoundaryCount(int[] nums)
    {
        var position = 0;
        var result = 0;
        foreach (var n in nums)
        {
            position += n;
            if (position == 0) result++;
        }
        return result;
    }
    public static TheoryData<int[], int> TestData => new()
    {
        {[2,3,-5], 1},
        {[3,2,-3,-4], 0},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = ReturnToBoundaryCount(input);
        Assert.Equal(expected, actual);
    }
}