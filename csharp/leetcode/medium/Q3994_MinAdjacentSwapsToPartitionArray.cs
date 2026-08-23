public class Q3994_MinAdjacentSwapsToPartitionArray
{
    public int MinAdjacentSwaps(int[] nums, int a, int b)
    {
        return 0;
    }

    public static TheoryData<int[], int, int, int> TestData => new()
    {
        // 9,7,5,3,4,6
        { [9, 7, 5, 3], 4, 8, 5 },
        { [1, 3, 2, 4, 5, 6], 3, 4, 1 },
        { [3, 7, 5, 9], 4, 8, 0 }
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int a, int b, int expected)
    {
        var actual = MinAdjacentSwaps(input, a, b);
        Assert.Equal(expected, actual);
    }
}
