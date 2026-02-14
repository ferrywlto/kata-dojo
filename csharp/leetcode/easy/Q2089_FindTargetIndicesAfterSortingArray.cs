public class Q2089_FindTargetIndicesAfterSortingArray
{
    // TC: O(n), where n scale with length of nums, once for counting how many items are target while counting how many less than target.
    // SC: O(m), where m scale with items equals to target to hold the result; 
    public IList<int> TargetIndices(int[] nums, int target)
    {
        var targetCount = 0;
        var lessThanCount = 0;
        foreach (var n in nums)
        {
            if (n == target) targetCount++;
            else if (n < target) lessThanCount++;
        }
        if (targetCount == 0) return [];

        var list = new List<int>();
        for (var i = 0; i < targetCount; i++)
        {
            list.Add(lessThanCount + i);
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
