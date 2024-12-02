public class Q2535_DifferenceBetweenElementSumAndDigitSumOfArray
{
    public int DifferenceOfSum(int[] nums)
    {
        return 0;
    }
    public static List<object[]> TestData =>
    [
        [new int[] {1,15,6,3}, 9],
        [new int[] {1,2,3,4}, 0],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = DifferenceOfSum(input);
        Assert.Equal(expected, actual);
    }
}