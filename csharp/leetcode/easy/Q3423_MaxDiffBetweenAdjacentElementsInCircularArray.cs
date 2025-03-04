public class Q3423_MaxDiffBetweenAdjacentElementsInCircularArray
{
    public int MaxAdjacentDistance(int[] nums)
    {
        return 0;
    }
    public static TheoryData<int[], int> TestData => new()
    {
        {[1,2,4], 3},
        {[-5,-10,-5], 3},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = MaxAdjacentDistance(input);
        Assert.Equal(expected, actual);
    }
}