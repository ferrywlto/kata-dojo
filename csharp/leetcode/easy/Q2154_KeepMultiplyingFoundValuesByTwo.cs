public class Q2154_KeepMultiplyingFoundValuesByTwo
{
    // TC: O(n log n), n scale with length of nums, dominant by Array.Sort() thus n log n times log n for binary search, 
    // SC: O(1), space used does not scale with input
    public int FindFinalValue(int[] nums, int original)
    {
        Array.Sort(nums);
        var result = original;
        var searchResult = Array.BinarySearch(nums, result);

        while (searchResult >= 0)
        {
            result = nums[searchResult] * 2;
            searchResult = Array.BinarySearch(nums,
                searchResult, nums.Length - searchResult, result);
        }
        return result;
    }
    public static List<object[]> TestData =>
    [
        [new int[] {5,3,6,1,12}, 3, 24],
        [new int[] {2,7,9}, 4, 4],
        [new int[] {2}, 2, 4],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int original, int expected)
    {
        var actual = FindFinalValue(input, original);
        Assert.Equal(expected, actual);
    }
}
