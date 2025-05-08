
public class Q1315_SumNodesWithEvenValueGrandParent(ITestOutputHelper output) : TreeNodeTest(output)
{
    // TC: O(n), n scale with number of nodes in tree
    // SC: O(d), d scale with depth of tree for recursion stack
    public int SumEvenGrandparent(TreeNode root)
    {
        return SumGrandChild(root);
    }
    private int SumGrandChild(TreeNode? node)
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
        return temp + SumGrandChild(node.left) + SumGrandChild(node.right);
    }
    public int SumEvenGrandparent_Faster(TreeNode root)
    {
        return SumGrandChild_Faster(root, false);
    }
    // This check less condition thus faster
    private int SumGrandChild_Faster(TreeNode? node, bool evenParent)
    {
        if (node == null) return 0;

        var temp = 0;
        if (evenParent)
        {
            temp += node.left?.val ?? 0;
            temp += node.right?.val ?? 0;
        }
        evenParent = node.val % 2 == 0;

        return temp + SumGrandChild_Faster(node.left, evenParent) + SumGrandChild_Faster(node.right, evenParent);
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
        var actual = SumEvenGrandparent_Faster(input);
        Assert.Equal(expected, actual);
    }
}