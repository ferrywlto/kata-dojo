
public class Q654_MaxBinaryTree(ITestOutputHelper output) : TreeNodeTest(output)
{
    // TC: O(n^2), n scale with length nums, worst case if sorted always run to end to get the max
    // SC: O(n), for the recursion stack
    public TreeNode ConstructMaximumBinaryTree(int[] nums)
    {
        return FindMaxNode(nums, 0, nums.Length - 1)!;
    }
    private TreeNode? FindMaxNode(int[] nums, int startIdx, int endIdx)
    {
        if (
            startIdx > endIdx ||
            startIdx < 0 || endIdx < 0 ||
            startIdx > nums.Length || endIdx > nums.Length
        )
        {
            return null;
        }
        if (startIdx == endIdx) return new TreeNode(nums[startIdx]);
        var maxIdx = -1;
        var max = -1;
        for (var i = startIdx; i <= endIdx; i++)
        {
            if (nums[i] > max)
            {
                max = nums[i];
                maxIdx = i;
            }
        }

        var node = new TreeNode(max)
        {
            left = FindMaxNode(nums, startIdx, maxIdx - 1),
            right = FindMaxNode(nums, maxIdx + 1, endIdx)
        };

        return node;
    }
    public static TheoryData<int[], TreeNode> TestData => new()
    {
        {[3,2,1,6,0,5], TreeNode.FromLevelOrderingIntArray([6,3,5,null,2,0,null,null,1])!},
        {[3,2,1], TreeNode.FromLevelOrderingIntArray([3,null,2,null,1])!},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, TreeNode expected)
    {
        var actual = ConstructMaximumBinaryTree(input);
        DebugTree(actual);
        AssertTreeNodeEqual(expected, actual);
        // Assert.Equal(expected, actual);
    }
}