public class Q2455_AvgValueOfEvenNumbersThatAreDivisibleByThree
{
    public int AverageValue(int[] nums)
    {
        return 0;
    }
    public static List<object[]> TestData =>
    [
        [new int[] {1,3,6,10,12,15}, 9],
        [new int[] {1,2,4,7,10}, 9],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = AverageValue(input);
        Assert.Equal(expected, actual);
    }
}