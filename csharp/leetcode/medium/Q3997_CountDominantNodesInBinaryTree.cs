public class Q3997_CountDominantNodesInBinaryTree
{
    public int CountDominantNodes(TreeNode root)
    {
        return 0;
    }

    public static TheoryData<TreeNode, int> TestData => new()
    {
        { TreeNode.FromLevelOrderingIntArray([5, 3, 8, 2, 4, 7, 1])!, 5 },
        { TreeNode.FromLevelOrderingIntArray([1, 2, 3, 1, 2])!, 4 },
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(TreeNode node, int expected)
    {
        var actual = CountDominantNodes(node);
        Assert.Equal(expected, actual);
    }
}
