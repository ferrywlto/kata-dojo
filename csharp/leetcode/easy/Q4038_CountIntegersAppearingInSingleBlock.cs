public class Q4038_CountIntegersAppearingInSingleBlock
{
    public int CountSpecialIntegers(int[] nums)
    {
        return 0;
    }

    public static TheoryData<int[], int> TestData => new()
    {
        { [1, 2, 2, 1], 1 },
        { [3, 3, 1, 2, 2, 1], 2 },
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = CountSpecialIntegers(input);
        Assert.Equal(expected, actual);
    }
}
