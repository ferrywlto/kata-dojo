using dojo.leetcode;

public class Q104_MaxDepthBinaryTreeTestData : TestDataBase
{
    protected override List<object[]> Data =>
    [
        [new int?[]{3, 9, 20, null, null, 15, 7}, 3],
        [new int?[]{1, null, 2}, 2],
        [Array.Empty<int?>(), 0],
        [new int?[]{0}, 1],
        [new int?[]{1,2}, 2],
    ];
}
public class Q104_MaxDepthBinaryTreeTests
{
    [Theory]
    [ClassData(typeof(Q104_MaxDepthBinaryTreeTestData))]
    public void OfficialTestCases(int?[] input, int expected)
    {
        var sut = new Q104_MaxDepthBinaryTree();
        var tree = TreeNode.FromLevelOrderingIntArray(input);
        var actual = sut.MaxDepth_Iterative(tree!);
        Assert.Equal(expected, actual);
    }
}

public class Q104_MaxDepthBinaryTree
{
    // TC: O(n), SC: O(n)
    public int MaxDepth(TreeNode root)
    {
        return root == null? 0 : 1 + Math.Max(MaxDepth(root.left!), MaxDepth(root?.right!));
    }

    // Demonstrate iterative solution in addition to recursive solution
    public int MaxDepth_Iterative(TreeNode root)
    {
        if (root == null) return 0;

        var stack = new Stack<(TreeNode, int)>();
        stack.Push((root, 1));
        var max = 1;

        while (stack.Count > 0) 
        {
            var (node, depth) = stack.Pop();

            if (node != null) 
            {
                max = Math.Max(max, depth);
                stack.Push((node.left!, depth + 1));
                stack.Push((node.right!, depth + 1));
            }
        }
        return max;
    }
}