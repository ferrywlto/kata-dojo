using dojo.leetcode;

public class Q145_PostorderTraversalBinaryTreeTestData : LeetCodeTestData
{
    protected override List<object[]> Data() =>
    [
        [new int?[] { 1, null, 2, 3 }, new int[] { 3, 2, 1 }],
        [new int?[] { 1 }, new int[] { 1 }],
        [Array.Empty<int?>(), Array.Empty<int>()],
    ];
}
public class Q145_PostorderTraversalBinaryTreeTests : TreeNodeTests
{
    [Theory]
    [ClassData(typeof(Q145_PostorderTraversalBinaryTreeTestData))]
    public void OfficialTestCases(int?[] input, int[] expected)
    {
        var sut = new Q145_PostorderTraversalBinaryTree();
        var tree = TreeNode.FromLevelOrderingIntArray(input);
        var actual = sut.PostorderTraversal(tree);

        Console.WriteLine($"expected: {string.Join(',', expected)}");
        Console.WriteLine($"actual: {string.Join(',', actual.ToArray())}");
        Assert.True(Enumerable.SequenceEqual(expected, actual.ToArray()));
    }
}

public class Q145_PostorderTraversalBinaryTree
{
    public IList<int> PostorderTraversal(TreeNode? root)
    {
        var result = new List<int>();
        PostorderTraversal_Recursion(root, result);
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
}