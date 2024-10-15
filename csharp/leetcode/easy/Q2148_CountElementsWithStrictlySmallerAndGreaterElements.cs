public class Q2148_CountElementsWithStrictlySmallerAndGreaterElements
{
    // TC: O(nlogn), n scale with length of nums, dominant by Array.Sort()
    // SC: O(1), space used does not scale with input
    public int CountElements(int[] nums)
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