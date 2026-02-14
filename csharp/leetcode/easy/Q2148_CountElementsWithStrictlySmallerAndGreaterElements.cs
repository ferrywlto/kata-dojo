public class Q2148_CountElementsWithStrictlySmallerAndGreaterElements
{
    // For question constraints, nums.Length max is 100 thus brute force is acceptable.
    // Attempt to provide a non-brute-force based appraoch. 
    // TC: O(n log n), due to OrderBy()
    // SC: O(m), m scale with unique numbers in nums
    public int CountElements(int[] nums)
    {
        if (nums.Length < 3) return 0;

        var set = nums.ToHashSet();
        var sorted = set.OrderBy(x => x).ToArray();
        var dict = new Dictionary<int, int>();
        for (var i = 0; i < sorted.Length; i++)
        {
            dict.Add(sorted[i], i);
        }

        var result = 0;
        foreach (var n in nums)
        {
            var idx = dict[n];
            var inRange = idx > 0 && idx < dict.Count - 1;
            if (inRange) result++;
        }

        return result;
    }
    // TC: O(n^2), n scale with length of nums, for each n it has to travel the whole array worst case (all items are equal)
    // SC: O(1), space used does not scale with input
    public int CountElements2(int[] nums)
    {
        Array.Sort(nums);

        var result = 0;
        for (var i = 1; i < nums.Length - 1; i++)
        {
            var hasSmaller = false;
            var hasLarger = false;
            for (var j = i - 1; j >= 0; j--)
            {
                if (nums[j] < nums[i])
                {
                    hasSmaller = true;
                    break;
                }
            }
            for (var k = i + 1; k < nums.Length; k++)
            {
                if (nums[k] > nums[i])
                {
                    hasLarger = true;
                    break;
                }
            }
            if (hasSmaller && hasLarger) result++;
        }
        return result;
    }
    public static List<object[]> TestData =>
    [
        [new int[] {11,7,2,15}, 2],
        [new int[] {-3,3,3,90}, 2],
        [new int[] {1}, 0],
        [new int[] {-89,39,39,-89,39,39}, 0],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = CountElements(input);
        Assert.Equal(expected, actual);
    }
}
