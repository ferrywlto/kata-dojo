
class Q145_PostorderTraversalBinaryTreeTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int?[] { 1, 2, 3, 4, 5, 6, 7 }, new int[] { 4, 5, 2, 6, 7, 3, 1 }],
        [new int?[] { 1, null, 2, 3 }, new int[] { 3, 2, 1 }],
        [new int?[] { 1 }, new int[] { 1 }],
        [Array.Empty<int?>(), Array.Empty<int>()],
    ];
}

public class Q145_PostorderTraversalBinaryTreeTests(ITestOutputHelper output) : TreeNodeTest(output)
{
    [Theory]
    [ClassData(typeof(Q145_PostorderTraversalBinaryTreeTestData))]
    public void OfficialTestCases(int?[] input, int[] expected)
    {
        var sut = new Q145_PostorderTraversalBinaryTree();
        var tree = TreeNode.FromLevelOrderingIntArray(input);
        var actual = sut.PostorderTraversal(tree);

        Output.WriteLine($"expected: {string.Join(',', expected)}");
        Output.WriteLine($"actual: {string.Join(',', actual.ToArray())}");
        Assert.Equal(expected, actual.ToArray());
    }
}

class Q145_PostorderTraversalBinaryTree
{
    public IList<int> PostorderTraversal(TreeNode? root)
    {
        // var result = new List<int>();
        // PostorderTraversal_Recursion(root, result);
        var result = PostorderTraversal_Iteration(root);
        return result;
    }
    // TC: O(num_nodes), SC: O(height_of_tree)
    public void PostorderTraversal_Recursion(TreeNode? node, List<int> result)
    {
        if (node == null) return;
        PostorderTraversal_Recursion(node.left, result);
        PostorderTraversal_Recursion(node.right, result);
        result.Add(node.val);
    }

    // Demonstration of using iterative approach, which needs to do a reverse at the end
    // Another approach I can think of is to use two stacks, one for traversal, one for result
    // This is because no matter what approach we use, the result is always in reverse postorder traversal 
    public List<int> PostorderTraversal_Iteration(TreeNode? root)
    {
        var result = new List<int>();
        if (root == null) return result;

        var stack = new Stack<TreeNode>();
        stack.Push(root);

        TreeNode? node;

        while (stack.Count > 0)
        {
            node = stack.Pop();
            result.Add(node.val);

            if (node.left != null)
                stack.Push(node.left);
            if (node.right != null)
                stack.Push(node.right);
        }
        result.Reverse();
        return result;
    }
}