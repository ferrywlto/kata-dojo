public class Q1979_FindGreatestCommonDivisorOfArray
{
    public int FindGCD(int[] nums)
    {
        return 0;
    }
    public static List<object[]> TestData =>
    [
        [new int[]{2,5,6,9,10}, 2],
        [new int[]{7,5,6,8,3}, 3],
        [new int[]{3,3}, 3],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = FindGCD(input);
        Assert.Equal(expected, actual);
    }
}