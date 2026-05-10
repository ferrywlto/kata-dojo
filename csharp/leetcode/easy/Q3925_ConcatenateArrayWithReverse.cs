public class Q3925_ConcatenateArrayWithReverse
{
    public int[] ConcatWithReverse(int[] nums)
    {
        return [];
    }

    public static TheoryData<int[], int[]> TestData = new()
    {
        { [1, 2, 3], [1, 2, 3, 3, 2, 1] },
        { [1], [1, 1] },
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int[] expected)
    {
        var actual = ConcatWithReverse(input);
        Assert.Equal(expected, actual);
    }
}
