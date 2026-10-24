public class Q4088_DifferenceBetweenPeaksAndValleys
{
    public int PeakValleyDifference(int[] nums)
    {
        return 0;
    }

    public static TheoryData<int[], int> TestData => new()
    {
        { [1, 5, 2, 4, 1, 3, 0], 9 },
        { [-5, -6, -1, -2, 5, 3, 2], 12 },
        { [6, 5, 2, 5, 5, 3, 6], -5 },
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = PeakValleyDifference(input);
        Assert.Equal(expected, actual);
    }
}
