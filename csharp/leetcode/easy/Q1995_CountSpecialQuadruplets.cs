public class Q1995_CountSpecialQuadruplets
{
    public int CountQuadruplets(int[] nums)
    {
        return 0;
    }
    public static List<object[]> TestData =>
    [
        [new int[] {1,2,3,6}, 1],
        [new int[] {3,3,6,4,5}, 0],
        [new int[] {1,1,1,3,5}, 4],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = CountQuadruplets(input);
        Assert.Equal(expected, actual);
    }
}