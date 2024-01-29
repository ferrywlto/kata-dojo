
namespace dojo.leetcode;

public class Q222_CountCompleteTreeNodes
{
    // Constraints: O(log n), at most O((log n)^2), still need to be recursive, 
    // iterative approach requires using quene and even slower : O(n)
    // Complete tree properties:
    // If left subtree height == right subtree height => left subtree must perfect, left nodes = 2^(subtree height-1), only need to calculate the right subtree
    // else the right subtree must be perfrect and left is complete, right nodes = 2^(subtree height-1), only need to calculate to left subtree
    // THe height difference between left and right subtree cannot > 1 
    // Repeat until no more subtree, each iteration the complete subtree will shrink half
    public int CountNodes(TreeNode? root) 
    {
        return CountNodes(root, -1);
    }

    private int CountNodes(TreeNode? node, int height)
    {
        if (node == null) return 0;

        if (height == -1) height = GetHeight(node);

        int leftHeight = node.left != null ? height - 1 : -1;
        int rightHeight = node.right != null ? height - 1 : -1;

        if (leftHeight == rightHeight)
        {
            // left subtree is perfect binary tree
            return (1 << leftHeight) + CountNodes(node.right, rightHeight);
        }
        else
        {
            // right subtree is perfect binary tree
            return (1 << rightHeight) + CountNodes(node.left, leftHeight);
        }
    }

    private int GetHeight(TreeNode? node)
    {
        if (node == null) return 0;
        // as it's a complete binary tree, it cannot be right only
        // either left only, left and right thus just need to count left
        return 1 + GetHeight(node.left); 
    }

    // try recursive O(n) first
    public int CountRecursive(TreeNode? node)
    {
        if (node == null) return 0;
        else if (node.left == null && node.right == null) return 1;
        else if (node.left == null) return 1 + CountRecursive(node.right);
        else if (node.right == null) return 1 + CountRecursive(node.left);
        else return 1 + CountRecursive(node.left) + CountRecursive(node.right);
    }
}

public class Q222_CountCompleteTreeNodesTestData: TestData
{
    protected override List<object[]> Data => 
    [
        [new int[]{1,2,3,4,5,6}, 6],
        [Array.Empty<int>(), 0],
        [new int[]{1}, 1],
    ];
}

public class Q222_CountCompleteTreeNodesTests(ITestOutputHelper output): BaseTest(output)
{
    [Theory]
    [ClassData(typeof(Q222_CountCompleteTreeNodesTestData))]
    public void OfficialTestCases(int[] input, int expected)
    {
        var converted = Array.ConvertAll<int, int?>(input, x => x);
        var tree = TreeNode.FromLevelOrderingIntArray(converted);
        var sut = new Q222_CountCompleteTreeNodes();
        var actual = sut.CountRecursive(tree);
        Assert.Equal(expected, actual);
    }
}
