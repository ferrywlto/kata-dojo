public class Q2367_NumArithmeticTriplets
{
    public int ArithmeticTriplets(int[] nums, int diff)
    {
        return 0;
    }
    public static List<object[]> TestData =>
    [
        [new int[] {0,1,4,6,7,10}, 3, 2],
        [new int[] {4,5,6,7,8,9}, 2, 2],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int diff, int expected)
    {
        var actual = ArithmeticTriplets(input, diff);
        Assert.Equal(expected, actual);
    }
}