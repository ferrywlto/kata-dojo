public class Q2275_LargestCombinationWithBitwiseAndGreaterThanZero
{
    public int LargestCombination(int[] candidates)
    {
        return 0;
    }
    public static TheoryData<int[], int> TestData => new()
    {
        {[16,17,71,62,12,24,14], 4},
        {[8,8], 4},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = LargestCombination(input);
        Assert.Equal(expected, actual);
    }
}
