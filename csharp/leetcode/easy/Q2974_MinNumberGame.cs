public class Q2974_MinNumberGame
{
    public int[] NumberGame(int[] nums)
    {
        return [];
    }
    public static TheoryData<int[], int[]> TestData => new()
    {
        {[5,4,2,3], [3,2,5,4]},
        {[2,5], [5,2]},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int[] expected)
    {
        var actual = NumberGame(input);
        Assert.Equal(expected, actual);
    }
}
