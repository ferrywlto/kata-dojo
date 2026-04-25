public class Q3861_MinCapacityBox
{
    // TC: O(n), n scale with length of capacity
    // SC: O(1), space used does not scale with input
    public int MinimumIndex(int[] capacity, int itemSize)
    {
        var minSize = int.MaxValue;
        var resultIdx = -1;
        for (var i = 0; i < capacity.Length; i++)
        {
            if (capacity[i] >= itemSize && capacity[i] < minSize)
            {
                minSize = capacity[i];
                resultIdx = i;
            }
        }

        return resultIdx;
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
