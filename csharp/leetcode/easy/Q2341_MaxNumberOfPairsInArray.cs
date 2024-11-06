public class Q2341_MaxNumberOfPairsInArray
{
    public int[] NumberOfPairs(int[] nums)
    {
        return [];
    }
    public static List<object[]> TestData =>
    [
        [new int[] {1,3,2,1,3,2,2}, new int[] {3,1}],
        [new int[] {1,1}, new int[] {1,0}],
        [new int[] {0}, new int[] {1}],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int[] expected)
    {
        var actual = NumberOfPairs(input);
        Assert.Equal(expected, actual);
    }
}