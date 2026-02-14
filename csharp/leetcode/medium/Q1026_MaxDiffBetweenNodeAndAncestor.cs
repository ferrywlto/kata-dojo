public class Q1026_MaxDiffBetweenNodeAndAncestor(ITestOutputHelper output) : TreeNodeTest(output)
{
    // TC: O(d), d scale with depth of root
    // SC: O(d), each node holds all ancestors
    public int MaxAncestorDiff(TreeNode root)
    {
        FindMaxDiff(root, root.val, root.val);
        return maxDiff;
    }

    private int maxDiff = 0;
    private void FindMaxDiff(TreeNode? node, int min, int max)
    {
        if (node == null) return;

        var diffFromMin = Math.Abs(node.val - min);
        var diffFromMax = Math.Abs(node.val - max);
        var largerDiff = Math.Max(diffFromMin, diffFromMax);
        maxDiff = Math.Max(maxDiff, largerDiff);

        var newMin = Math.Min(min, node.val);
        var newMax = Math.Max(max, node.val);
        FindMaxDiff(node.left, newMin, newMax);
        FindMaxDiff(node.right, newMin, newMax);
    }

    public static TheoryData<TreeNode, int> TestData => new()
    {
        {TreeNode.FromLevelOrderingIntArray([8,3,10,1,6,null,14,null,null,4,7,13])!, 7},
        {TreeNode.FromLevelOrderingIntArray([1,null,2,null,0,3])!, 3},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(TreeNode node, int expected)
    {
        var actual = MaxAncestorDiff(node);
        Assert.Equal(expected, actual);
    }
}
