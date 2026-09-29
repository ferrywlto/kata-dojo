public class Q4065_RearrangeArrayByRemovingDistinctValues
{
    public int[] RearrangeArray(int[] nums)
    {
        return [];
    }

    public static TheoryData<int[], int[]> TestData => new()
    {
        {
            [3, 1, 3, 2, 1, 3], [1, 2, 3, 1, 3, 3]
        },
        {
            [7, 7, 4, 4, 4], [4, 7, 4, 7, 4]
        }
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int[] expected)
    {
        var actual = RearrangeArray(input);
        Assert.Equal(expected, actual);
    }
}
