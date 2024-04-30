class Q965_UnivaluedBinaryTree
{
    // TC: O(n), n is nodes on tree
    // SC: O(h), h is max height of tree
    public bool IsUnivalTree(TreeNode root)
    {
        var stack = new Stack<TreeNode>();
        var univalue = root.val;
        if (root.right != null) stack.Push(root.right);
        if (root.left != null) stack.Push(root.left);
        while (stack.Count > 0)
        {
            var node = stack.Pop();
            if (node.val != univalue) return false;

            if (node.right != null) stack.Push(node.right);
            if (node.left != null) stack.Push(node.left);
        }
        return true;
    }
}

class Q965_UnivaluedBinaryTreeTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int?[] {1,1,1,1,1,null,1}, true],
        [new int?[] {2,2,2,5,2}, false],
    ];
}

public class Q965_UnivaluedBinaryTreeTests
{
    [Theory]
    [ClassData(typeof(Q965_UnivaluedBinaryTreeTestData))]
    public void OfficialTestCases(int?[] input, bool expected)
    {
        var sut = new Q965_UnivaluedBinaryTree();
        var tree = TreeNode.FromLevelOrderingIntArray(input);
        var actual = sut.IsUnivalTree(tree!);
        Assert.Equal(expected, actual);
    }
}