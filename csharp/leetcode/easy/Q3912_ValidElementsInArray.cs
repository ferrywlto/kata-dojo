public class Q3912_ValidElementsInArray
{
    // TC: O(n), n scale with length of nums
    // SC: O(n)
    public IList<int> FindValidElements(int[] nums)
    {
        var len = nums.Length;
        if (len == 1) return nums;

        var result = new List<int>() { nums[0] };
        Span<int> largestFromLeft = stackalloc int[len];
        Span<int> largestFromRight = stackalloc int[len];
        var maxLeft = nums[0];
        largestFromLeft[0] = maxLeft;
        var maxRight = nums[len - 1];
        largestFromRight[len - 1] = maxRight;

        for (var i = 1; i < len; i++)
        {
            var idxFromEnd = len - 1 - i;
            if (nums[i] > maxLeft) maxLeft = nums[i];
            if (nums[idxFromEnd] > maxRight) maxRight = nums[idxFromEnd];

            largestFromLeft[i] = maxLeft;
            largestFromRight[idxFromEnd] = maxRight;
        }

        for (var i = 1; i < len - 1; i++)
        {
            if (nums[i] > largestFromLeft[i - 1] ||
                nums[i] > largestFromRight[i + 1])
                result.Add(nums[i]);
        }

        result.Add(nums[len - 1]);
        return result;
    }

    public static TheoryData<int[], List<int>> TestData => new()
    {
        { [1, 2, 4, 2, 3, 2], [1, 2, 4, 3, 2] },
        { [5, 5, 5, 5], [5, 5] },
        { [1], [1] },
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, List<int> expected)
    {
        var actual = FindValidElements(input);
        Assert.Equal(expected, actual);
    }
}
