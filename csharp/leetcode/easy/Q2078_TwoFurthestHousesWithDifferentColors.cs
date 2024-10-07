public class Q2078_TwoFurthestHousesWithDifferentColors
{
    public int MaxDistance(int[] colors)
    {
        return 0;
    }
    public static List<object[]> TestData =>
    [
        [new int[] {1,1,1,6,1,1,1}, 3],
        [new int[] {1,8,3,8,3}, 4],
        [new int[] {0,1}, 1],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = MaxDistance(input);
        Assert.Equal(expected, actual);
    }
}