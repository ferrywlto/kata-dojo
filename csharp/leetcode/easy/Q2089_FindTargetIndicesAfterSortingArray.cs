public class Q2089_FindTargetIndicesAfterSortingArray
{
    // TC: O(nlogn), where n scale with length of nums, due to Array.Sort();
    // SC: O(m), where m scale with items equals to target to hold the result; 
    public IList<int> TargetIndices(int[] nums, int target)
    {
        Array.Sort(nums);
        var list = new List<int>();
        for (var i = 0; i < nums.Length; i++)
        {
            if (nums[i] == target) list.Add(i);
        }
        return list;
    }
    public static List<object[]> TestData =>
    [
        [new int[] {1,2,5,2,3}, 2, new List<int> {1,2}],
        [new int[] {1,2,5,2,3}, 3, new List<int> {3}],
        [new int[] {1,2,5,2,3}, 5, new List<int> {4}],
        [new int[] {1,2,5,2,3}, 6, new List<int> {}],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int target, List<int> expected)
    {
        var actual = TargetIndices(input, target);
        Assert.Equal(expected, actual);
    }
}