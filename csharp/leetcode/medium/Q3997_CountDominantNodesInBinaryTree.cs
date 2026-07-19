public class Q3997_CountDominantNodesInBinaryTree
{
    // TC: O(n)
    // SC: O(1)
    public int CountDominantNodes(TreeNode root)
    {
        var (_, count) = GetMax(root);
        return count;
    }

    private (int max, int dominantCount) GetMax(TreeNode? node)
    {
        if (node is null) return (0, 0);

        // IsLeaf
        if (node.left is null && node.right is null)
            return (node.val, 1);

        var (leftMax, leftDominantCount) = GetMax(node.left);
        var (rightMax, rightDominantCount) = GetMax(node.right);
        var subtreeMax = Math.Max(leftMax, rightMax);

        if (node.val >= subtreeMax)
            return (node.val, 1 + leftDominantCount + rightDominantCount);

        return (subtreeMax, leftDominantCount + rightDominantCount);
    }

    public static TheoryData<TreeNode, int> TestData => new()
    {
        { TreeNode.FromLevelOrderingIntArray([5, 3, 8, 2, 4, 7, 1])!, 5 },
        { TreeNode.FromLevelOrderingIntArray([1, 2, 3, 1, 2])!, 4 },
        { TreeNode.FromLevelOrderingIntArray([7, 1])!, 2 },
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(TreeNode node, int expected)
    {
        var actual = CountDominantNodes(node);
        Assert.Equal(expected, actual);
    }
}
