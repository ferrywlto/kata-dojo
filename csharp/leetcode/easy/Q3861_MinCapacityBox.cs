public class Q3861_MinCapacityBox
{
    public int MinimumIndex(int[] capacity, int itemSize)
    {
        return 0;
    }

    public static TheoryData<int[], int, int> TestData => new()
    {
        { [1, 5, 3, 7], 3, 2 }, { [3, 5, 4, 3], 2, 0 }, { [4], 5, -1 }
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int size, int expected)
    {
        var actual = MinimumIndex(input, size);
        Assert.Equal(expected, actual);
    }
}
