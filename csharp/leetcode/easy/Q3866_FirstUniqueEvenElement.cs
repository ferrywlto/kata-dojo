public class Q3866_FirstUniqueEvenElement
{
    // TC: O(n), n scale with length of nums
    // SC: O(1), space used does not scale with input
    public int FirstUniqueEven(int[] nums)
    {
        Span<int> freq = stackalloc int[101];
        Span<int> pos = stackalloc int[101];
        for (var i = 0; i < pos.Length; i++) pos[i] = -1;

        for (var i = 0; i < nums.Length; i++)
        {
            freq[nums[i]]++;

            if (pos[nums[i]] == -1)
                pos[nums[i]] = i;
        }

        var result = -1;
        var resultIdx = int.MaxValue;
        for (var i = 2; i < pos.Length; i += 2)
        {
            if (freq[i] == 1 && pos[i] < resultIdx)
            {
                resultIdx = pos[i];
                result = i;
            }
        }

        return result;
    }

    public static TheoryData<int[], int> TestData => new() { { [3, 4, 2, 5, 4, 6], 2 }, { [4, 4], -1 }, { [2], 2 } };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = FirstUniqueEven(input);
        Assert.Equal(expected, actual);
    }
}
