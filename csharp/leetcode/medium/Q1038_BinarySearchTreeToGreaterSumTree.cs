
public class Q1038_BinarySearchTreeToGreaterSumTree(ITestOutputHelper output) : TreeNodeTest(output)
{
    // TC: O(n), n scale with number of nodes in tree
    // SC: O(d), d scale with the max depth of the tree
    // This solution solve in single pass
    public TreeNode BstToGst(TreeNode root)
    {
        var sum = 0;
        var stack = new Stack<TreeNode>();
        var curr = root;
        stack.Push(curr);

        while (stack.Count > 0)
        {
            // curr = stack.Peek();
            while (curr!.right != null)
            {
                stack.Push(curr.right);
                curr = curr.right;
            }

            // process node
            var node = stack.Pop();
            var temp = node.val;
            node.val += sum;
            sum += temp;

            Output.WriteLine(node.val.ToString());

            if (node.left != null)
            {
                stack.Push(node.left);
                curr = node.left;
            }
        }
        return root;
    }
    public static TheoryData<TreeNode, TreeNode> TestData => new()
    {
        {
            TreeNode.FromLevelOrderingIntArray([4,1,6,0,2,5,7,null,null,null,3,null,null,null,8])!,
            TreeNode.FromLevelOrderingIntArray([30,36,21,36,35,26,15,null,null,null,33,null,null,null,8])!
        },
        {
            TreeNode.FromLevelOrderingIntArray([0,null,1])!,
            TreeNode.FromLevelOrderingIntArray([1,null,1])!
        }
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(TreeNode input, TreeNode expected)
    {
        var actual = BstToGst(input);
        AssertTreeNodeEqual(expected, actual);
    }
}