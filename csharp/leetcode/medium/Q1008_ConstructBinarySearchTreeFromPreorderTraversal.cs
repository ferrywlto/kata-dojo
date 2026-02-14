public class Q1008_ConstructBinarySearchTreeFromPreorderTraversal(ITestOutputHelper output) : TreeNodeTest(output)
{
    // TC: (n * d), n scale with length of preorder, d scale with depth of result tree
    // SC: O(d), d scale with depth of tree for stack used in search
    public TreeNode BstFromPreorder(int[] preorder)
    {
        var idx = 0;
        var root = new TreeNode(preorder[idx]);

        for (var i = 1; i < preorder.Length; i++)
        {
            AddNode(root, preorder[i]);
        }
        return root;
    }
    private void AddNode(TreeNode root, int val)
    {
        var stack = new Stack<TreeNode>();
        stack.Push(root);
        while (stack.Count > 0)
        {
            var node = stack.Pop();
            if (val < node.val)
            {
                if (node.left == null)
                {
                    node.left = new TreeNode(val);
                    return;
                }
                else
                {
                    stack.Push(node.left);
                }
            }
            else
            {
                if (node.right == null)
                {
                    node.right = new TreeNode(val);
                    return;
                }
                else
                {
                    stack.Push(node.right);
                }
            }
        }
    }

    public static TheoryData<int[], TreeNode> TestData => new()
    {
        {[8,5,1,7,10,12], TreeNode.FromLevelOrderingIntArray([8,5,10,1,7,null,12])!},
        {[1,3], TreeNode.FromLevelOrderingIntArray([1,null,3])!},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, TreeNode expected)
    {
        var actual = BstFromPreorder(input);
        AssertTreeNodeEqual(expected, actual);
    }
}
