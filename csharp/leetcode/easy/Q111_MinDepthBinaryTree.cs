using dojo.leetcode;

public class Q111_MinDepthBinaryTreeTestData : LeetCodeTestData
{
    protected override List<object[]> Data() =>
    [
        [new int?[]{3,9,20,null,null,15,7}, 2],
        [new int?[]{2,null,3,null,4,null,5,null,6}, 5],
    ];
}
public class Q111_MinDepthBinaryTreeTests
{
    [Theory]
    [ClassData(typeof(Q111_MinDepthBinaryTreeTestData))]
    public void OfficialTestCases(int?[] input, int expected)
    {
        var sut = new Q111_MinDepthBinaryTree();
        var tree = TreeNode.FromLevelOrderingIntArray(input);
        var actual = sut.MinDepth(tree!);
        Assert.Equal(expected, actual);
    }
}

public class Q111_MinDepthBinaryTree
{
    // TC: O(n), SC: O(n)
    public int MinDepth(TreeNode root)
    {
        return root == null? 0 : 1 + Math.Min(MinDepth(root.left!), MinDepth(root?.right!));
    }

    // Demonstrate iterative solution in addition to recursive solution
    public int MinDepth_Iterative(TreeNode root)
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