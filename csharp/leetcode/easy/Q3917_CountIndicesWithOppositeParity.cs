public class Q3917_CountIndicesWithOppositeParity
{
    // TC: O(n), n scale with length of nums
    // SC: O(n) for storing the result, otherwise O(1)
    public int[] CountOppositeParity(int[] nums)
    {
        var len = nums.Length;
        Span<int> result = stackalloc int[len];
        var oddCount = 0;
        var evenCount = 0;

        for (var i = 0; i < len; i++)
        {
            var idx = len - 1 - i;

            if (nums[idx] % 2 == 0)
            {
                result[idx] = oddCount;
                evenCount++;
            }
            else
            {
                result[idx] = evenCount;
                oddCount++;
            }
        }
        return result.ToArray();
    }

    public static TheoryData<int[], int[]> TestData => new()
    {
        { [1, 2, 3, 4], [2, 1, 1, 0] },
        { [1], [0] },
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int[] expected)
    {
        var actual = CountOppositeParity(input);
        Assert.Equal(expected, actual);
    }
}
