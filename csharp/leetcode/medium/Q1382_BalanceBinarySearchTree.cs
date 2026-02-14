public class Q1382_BalanceBinarySearchTree(ITestOutputHelper output) : TreeNodeTest(output)
{
    // Solution is to do inorder transversal to get a sorted node list.
    // Then reconstruct the tree back with binary search.
    // A even faster approach is to use Day-Stout-Warren Algorithm that can do in place balance, which involve tree rotation.
    // Keep this information as reference as this is far from day to day work.

    // TC: O(n), n scale with nodes in root.
    // SC: O(n), the sorted list need to hold all nodes from inorder transversal
    public TreeNode BalanceBST(TreeNode root)
    {
        var list = new List<int>();
        InorderTraversal(root, list);
        Output.WriteLine(string.Join(',', list));

        return BuildBST(list, 0, list.Count - 1)!;
    }
    private TreeNode? BuildBST(List<int> list, int left, int right)
    {
        if (left > right) return null;

        var middle = left + (right - left) / 2;

        var node = new TreeNode(list[middle])
        {
            left = BuildBST(list, left, middle - 1),
            right = BuildBST(list, middle + 1, right)
        };

        return node;
    }
    private void InorderTraversal(TreeNode? node, IList<int> result)
    {
        if (node != null)
        {
            InorderTraversal(node.left, result);
            result.Add(node.val);
            InorderTraversal(node.right, result);
        }
    }

    public static TheoryData<TreeNode, TreeNode> TestData => new()
    {
        {
            TreeNode.FromLevelOrderingIntArray([1,null,2,null,3,null,4,null,null])!,
            TreeNode.FromLevelOrderingIntArray([2,1,3,null,null,null,4])!
        },
        {
            TreeNode.FromLevelOrderingIntArray([2,1,3])!,
            TreeNode.FromLevelOrderingIntArray([2,1,3])!
        }
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(TreeNode input, TreeNode expected)
    {
        var actual = BalanceBST(input);
        DebugTree(actual);
        AssertTreeNodeEqual(expected, actual);
    }
}
