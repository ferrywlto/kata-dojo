public class Q3880_MinAbsoluteDiffBetweenTwoValues
{
    public int MinAbsoluteDifference(int[] nums)
    {
        return 0;
    }

    public static TheoryData<int[], int> TestData => new()
    {
        { [1, 0, 0, 2, 0, 1], 2 },
        {[1, 0, 1, 0], -1}
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = MinAbsoluteDifference(input);
        Assert.Equal(expected, actual);
    }
}
