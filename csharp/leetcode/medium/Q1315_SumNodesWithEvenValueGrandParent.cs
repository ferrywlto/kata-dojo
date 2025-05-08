
public class Q1315_SumNodesWithEvenValueGrandParent(ITestOutputHelper output) : TreeNodeTest(output)
{
    // TC: O(n), n scale with number of nodes in tree
    // SC: O(d), d scale with depth of tree for recursion stack
    public int SumEvenGrandparent(TreeNode root)
    {
        return Cal(root);
    }
    private int Cal(TreeNode? node)
    {
        if (node == null) return 0;
        var temp = 0;
        if (node.val % 2 == 0)
        {
            if (node.left?.left != null)
            {
                temp += node.left.left.val;
            }
            if (node.left?.right != null)
            {
                temp += node.left.right.val;
            }
            if (node.right?.left != null)
            {
                temp += node.right.left.val;
            }
            if (node.right?.right != null)
            {
                temp += node.right.right.val;
            }
        }
        return temp + Cal(node.left) + Cal(node.right);
    }
    public static TheoryData<TreeNode, int> TestData => new()
    {
        {TreeNode.FromLevelOrderingIntArray([6,7,8,2,7,1,3,9,null,1,4,null,null,null,5])!, 18},
        {TreeNode.FromLevelOrderingIntArray([1])!, 0}
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(TreeNode input, int expected)
    {
        var actual = SumEvenGrandparent(input);
        Assert.Equal(expected, actual);
    }
}