public class Q4048_CountValuesWithEquallySpacedOccurrencesI
{
    // TC: O(n)
    // SC: O(1)
    public int CountSpecialIntegers(int[] nums)
    {
        const int len = 101;
        var pos = new int[len][];
        for (var i = 0; i < len; i++)
        {
            pos[i] = new int[3];
        }

        var count = new int[len];

        for (var i = 0; i < nums.Length; i++)
        {
            var n = nums[i];
            if (count[n] < 3)
                pos[n][count[n]] = i;

            count[n]++;
        }

        var result = 0;
        for (var i = 0; i < len; i++)
        {
            if (count[i] != 3) continue;
            if (pos[i][2] - pos[i][1] == pos[i][1] - pos[i][0]) result++;
        }

        return result;
    }

    public static TheoryData<int[], int> TestData => new()
    {
        { [1, 8, 1, 5, 1, 5, 8, 5], 2 },
        { [8, 8, 8, 8], 0 },
        { [8, 8, 6, 6, 8], 0 },
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = CountSpecialIntegers(input);
        Assert.Equal(expected, actual);
    }
}
