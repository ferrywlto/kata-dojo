public class Q3909_CompareSumsOfBitonicParts
{
    // TC: O(n)
    // SC: O(1)
    public int CompareBitonicSums(int[] nums)
    {
        long ascendingSum = nums[0];
        long descendingSum = 0;
        var peakIdx = -1;

        for (var i = 1; i < nums.Length; i++)
        {
            if (nums[i] > nums[i - 1])
            {
                ascendingSum += nums[i];
            }
            else
            {
                peakIdx = i - 1;
                descendingSum = nums[peakIdx];
                break;
            }
        }

        for (var i = peakIdx + 1; i < nums.Length; i++)
        {
            descendingSum += nums[i];
        }

        if (ascendingSum > descendingSum) return 0;
        if (descendingSum > ascendingSum) return 1;
        return -1;
    }

    public static TheoryData<int[], int> TestData => new()
    {
        { [1, 3, 2, 1], 1 },
        { [2, 4, 5, 2], 0 },
        { [1, 2, 4, 3], -1 },
        { [30494606,875031872,850559628,844602130], 1 },
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = CompareBitonicSums(input);
        Assert.Equal(expected, actual);
    }
}
