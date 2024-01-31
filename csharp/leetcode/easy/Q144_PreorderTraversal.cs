namespace dojo.leetcode;

public class Q144_PreorderTraversalTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int?[] { 2,3,null,1 }, new int[] { 2,3,1 }],
        [new int?[] { 1, null, 2, 3 }, new int[] { 1, 2, 3 }],
        [new int?[] { 1 }, new int[] { 1 }],
        [Array.Empty<int?>(), Array.Empty<int>()],
    ];

}

public class Q144_PreorderTraversalTests(ITestOutputHelper output) : TreeNodeTests
{
    [Theory]
    [ClassData(typeof(Q144_PreorderTraversalTestData))]
    public void OfficialTestCases(int?[] input, int[] expected)
    {
        var sut = new Q144_PreorderTraversal();
        var tree = TreeNode.FromLevelOrderingIntArray(input);
        var actual = sut.PreorderTraversal(tree);

        output!.WriteLine($"expected: {string.Join(',', expected)}");
        output.WriteLine($"actual: {string.Join(',', actual.ToArray())}");
        Assert.True(Enumerable.SequenceEqual(expected, actual.ToArray()));
    }
}

public class Q144_PreorderTraversal
{
    public IList<int> PreorderTraversal(TreeNode? root)
    {
        if (root == null) return new List<int>();
        var result = new List<int>();
        // PreorderTraversal_Recursion(root, result);
        result = PreorderTraversal_Iteration(root);
        return result;
    }

    public void PreorderTraversal_Recursion(TreeNode? node, List<int> result)
    {
        if (node == null) return;
        result.Add(node.val);
        PreorderTraversal_Recursion(node.left, result);
        PreorderTraversal_Recursion(node.right, result);
    }

    // TC: O(num_nodes), SC: O(height_of_tree)
    public List<int> PreorderTraversal_Iteration(TreeNode? root)
    {
        if (root == null) return [];
        var result = new List<int>();
        var stack = new Stack<TreeNode>();
        stack.Push(root);

        TreeNode? node;
        while (stack.Count > 0)
        {
            node = stack.Pop();
            result.Add(node.val);

            if (node.right != null) stack.Push(node.right);
            if (node.left != null) stack.Push(node.left);
        }

        return result;
    }
}