public class Q2475_NumberOfUnequalTripletsInArray
{
    public int UnequalTriplets(int[] nums)
    {
        return 0;
    }
    public static List<object[]> TestData =>
    [
        [new int[] {4,4,2,4,3}, 3],
        [new int[] {1,1,1,1,1}, 0],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = UnequalTriplets(input);
        Assert.Equal(expected, actual);
    }
}
