public class Q3994_MinAdjacentSwapsToPartitionArray
{
    // TC: O(n)
    // SC: O(1)
    public int MinAdjacentSwaps(int[] nums, int a, int b)
    {
        var moves = 0L;
        Span<int> countGrp = stackalloc int[3];

        // keep track on group 2 and group 3 count
        // every group 1 number (< a) need previous known group 2 and group 3 count moves
        // every group 2 number ([a, b]) need previous known group 3 moves
        for (var i = 0; i < nums.Length; i++)
        {
            if (nums[i] < a)
            {
                moves += countGrp[2];
                moves += countGrp[1];
            }
            else if (nums[i] > b)
            {
                countGrp[2]++;
            }
            else
            {
                countGrp[1]++;
                moves += countGrp[2];
            }
        }

        long result = moves % (10_000_000_00 + 7);
        return (int)result;
    }

    public static TheoryData<int[], int, int, int> TestData => new()
    {
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
