public class Q2210_CountHillsAndValleysInArray
{
    public int CountHillValley(int[] nums)
    {
        return 0;
    }
    public static List<object[]> TestData =>
    [
        [new int[] {2,4,1,1,6,5}, 3],
        [new int[] {6,6,5,5,4,1}, 0],
        [new int[] {1,2,1}, 1],
        [new int[] {2,1,2}, 1],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = CountHillValley(input);
        Assert.Equal(expected, actual);
    }
}