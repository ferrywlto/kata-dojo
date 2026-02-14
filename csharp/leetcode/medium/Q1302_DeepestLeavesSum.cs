public class Q1302_DeepestLeavesSum
{
    // TC: O(n), n scale with number of nodes in tree
    // SC: O(d), d scale with number of levels that contains leave nodes 
    int deepestLevel = 0;
    Dictionary<int, int> sum = [];
    public int DeepestLeavesSum(TreeNode root)
    {
        RunSubTree(root, 0);
        return sum[deepestLevel];
    }
    private void RunSubTree(TreeNode? input, int level)
    {
        if (input == null) return;
        // if is leaf
        if (input.left == null && input.right == null)
        {
            if (!sum.TryGetValue(level, out var val))
            {
                sum.Add(level, input.val);
            }
            else sum[level] = val + input.val;
            if (level > deepestLevel)
            {
                deepestLevel = level;
            }
            return;
        }
        RunSubTree(input.left, level + 1);
        RunSubTree(input.right, level + 1);
    }
    public static TheoryData<TreeNode, int> TestData => new()
    {
        {TreeNode.FromLevelOrderingIntArray([1,2,3,4,5,null,6,7,null,null,null,null,8])!, 15},
        {TreeNode.FromLevelOrderingIntArray([6,7,8,2,7,1,3,9,null,1,4,null,null,null,5])!, 19},
        {TreeNode.FromLevelOrderingIntArray([1,2])!, 2},
        {TreeNode.FromLevelOrderingIntArray([1])!, 1},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(TreeNode input, int expected)
    {
        var actual = DeepestLeavesSum(input);
        Assert.Equal(expected, actual);
    }
}
