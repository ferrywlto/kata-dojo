public class Q3917_CountIndicesWithOppositeParity
{
    public int[] CountOppositeParity(int[] nums)
    {
        return [];
    }

    public static TheoryData<int[], int[]> TestData => new()
    {
        { [1, 2, 3, 4], [2, 1, 1, 0] },
        { [1], [0] },
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int[] expected)
    {
        var actual = CountOppositeParity(input);
        Assert.Equal(expected, actual);
    }
}
