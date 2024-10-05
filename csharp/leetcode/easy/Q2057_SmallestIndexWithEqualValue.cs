public class Q2057_SmallestIndexWithEqualValue
{
    public int SmallestEqual(int[] nums)
    {
        return -1;
    }
    public static List<object[]> TestData =>
    [
        [new int[] {0,1,2}, 0],
        [new int[] {4,3,2,1}, 2],
        [new int[] {1,2,3,4,5,6,7,8,9,0}, -1],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = SmallestEqual(input);
        Assert.Equal(expected, actual);
    }
}